using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using AutoMapper;
using Domain.Model;
using Infrastructure.Database.EFImplementations;
using Infrastructure.Database.Interfaces;
using WebApp.Models;
using WebApp.Models.Product;

namespace WebApp.Controllers
{
    public class CustomersController : Controller
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public CustomersController(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            IList<Customer> customers = _uow.Customers.GetAll();
            var viewModel = _mapper.Map<IList<Customer>>(customers);

            return View(viewModel);
        }

        public ActionResult Details(int? id)
        {
            if (id == null || id == 0)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var customer = _uow.Customers.Get((int)id);

            if (customer == null)
                return HttpNotFound("Customer not found!");

            var detailsCustomer = _mapper.Map<Customer>(customer);

            return View(detailsCustomer);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Customer createCustomer)
        {
            if (ModelState.IsValid)
            {
                var customer = _mapper.Map<Customer>(createCustomer);
                _uow.Customers.Create(customer);
                _uow.Save();
                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult Edit(int? id)
        {
            if (id == null || id == 0)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var customer = _uow.Customers.Get((int)id);

            if (customer == null)
                return HttpNotFound("Customer not found!");

            var editCustomer = _mapper.Map<Customer>(customer);

            return View(editCustomer);
        }

        [HttpPost]
        public ActionResult Edit(Customer editCustomer)
        {
            if (ModelState.IsValid)
            {
                var customer = _mapper.Map<Customer>(editCustomer);
                customer = _uow.Customers.Edit(customer);
                _uow.Save();

                return RedirectToAction("Index");

            }

            return View();
        }

        public ActionResult Delete(int? id)
        {
            if (id == null || id == 0)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var customer = _uow.Customers.Get((int)id);

            if (customer == null)
                return HttpNotFound("Customer not found!");

            var deleteCustomer = _mapper.Map<Customer>(customer);

            return View(deleteCustomer);
        }

        [HttpPost]
        public ActionResult Delete(Customer deleteCustomer)
        {
            if (ModelState.IsValid)
            {
                var customer = _mapper.Map<Customer>(deleteCustomer);
				if (!_uow.Customers.Delete(customer))
				{
                    return View();
				}
                _uow.Save();

                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
