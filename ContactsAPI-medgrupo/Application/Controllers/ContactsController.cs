using AutoMapper;
using ContactsAPI_medgrupo.Application.Services;
using ContactsAPI_medgrupo.Application.ViewModel;
using ContactsAPI_medgrupo.Domain.DTOs;
using ContactsAPI_medgrupo.Domain.Entities;
using ContactsAPI_medgrupo.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ContactsAPI_medgrupo.Application.Controllers
{
    [ApiController]
    [Route("api/v1/contacts")]
    public class ContactsController : ControllerBase
    {
        private readonly IContactRepository _contactRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<ContactsController> _logger;
        private readonly IContactService _contactService;

        public ContactsController(IContactRepository contactRepository, IMapper mapper, ILogger<ContactsController> logger, IContactService contactService)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
            _logger = logger;
            _contactService = contactService;
        }

        [HttpPost]
        [Route("/criar-contato")]
        public IActionResult CriarNovoContato(ContactViewModel contactView)
        {
            var birthday = _contactService.convertStringToDateTime(contactView.DataNascimento);

            var contact = new Contact(contactView.NomeContato, birthday, contactView.Sexo);

            _contactRepository.Add(contact);

            return Ok();
        }


        //Retorna todos os contatos cadastrados com status Ativo, exibindo somente ID e Nome na lista.
        [HttpGet]
        [Route("/get/listar-todos")]
        public IActionResult ListarTodosOsContatos() 
        { 
            var contacts = _contactRepository.GetAll();
            var listContactsDTO = _contactService.mapearContatosList(contacts);

            return Ok(listContactsDTO); 
        }

        //Retorna detalhes do contato utilizando o ID encontrado na lista de contados como parametro da pesquisa.
        [HttpGet]
        [Route("/get/{id}")]
        public IActionResult DetalhesContatoById(int id)
        {
            var contact = _contactRepository.GetContactById(id);
            
            var contactDTO = _contactService.mapearContactDetails(contact);
            return Ok(contactDTO);
        }

        [HttpPatch]
        [Route("/desativar")]
        public IActionResult DesativarContato(int id)
        {
            _contactRepository.DisableContact(id);
            return Ok();
        }

        [HttpPost]
        [Route("/delete/{id}")]
        public IActionResult ExcluirContato(int id)
        {
            _contactRepository.Delete(id);
            return Ok();
        }

    }
}
