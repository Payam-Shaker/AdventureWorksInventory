using AdventureWorksInventory.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using CrudOperations;


namespace AdventureWorksInventory.Controllers
{
    public class AddressController : Controller
    {
        private InventoryDBcontext _dbcontext;

        public AddressController(InventoryDBcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public IActionResult Index(int id)
        {
            var context = new Crud<Address>(_dbcontext);
            var result = context.GetById(id);

            //var addressId = _dbcontext.Addresses.Where(a => a.AddressID == id).FirstOrDefault();
            return View(result);
        }
        public IActionResult AddAddressIndex()
        {
            return RedirectToAction("Index", "NewAddress");
        }

        public IActionResult EditAddress(Address obj)
        {
            var context = new Crud<Address>(_dbcontext);
            var address = context.GetById(obj.AddressID);

            //var address = _dbcontext.Addresses.Where(a => a.AddressID == obj.AddressID).FirstOrDefault();

            var objToBeEdited = new Address
            {
                AddressID = address.AddressID,
                AddressLine1 = address.AddressLine1,
                AddressLine2 = address.AddressLine2,
                City = obj.City,
                StateProvince = address.StateProvince,
                CountryRegion = address.CountryRegion,
                PostalCode = obj.PostalCode,
                rowguid = address.rowguid,
                ModifiedDate = System.DateTime.Now

            };
            //_dbcontext.Database.BeginTransactionAsync()
            context.Update(objToBeEdited);
            //_dbcontext.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Delete(int id)
        {
            var context = new Crud<Address>(_dbcontext);
            //var address = context.GetById(id);
            //var address = _dbcontext.Addresses.Where(a => a.AddressID == id).FirstOrDefault();
            //_dbcontext.Addresses.Remove(address);
            //_dbcontext.SaveChanges();



            context.Delete(id);
            return RedirectToAction("Index", "Home");

        }

    }
}
