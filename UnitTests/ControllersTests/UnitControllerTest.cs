using System.Transactions;
using Application.Repositories;
using Application.Services.Unit;
using Application.Services.Unit.Dto;
using FitnessBattle.Controllers;
using Infrastructure.SqlServer.Unit;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;

namespace FitnessBattle.ControllersTests
{
    //contains NUnit test cases for UnitController
    [TestFixture]
    public class UnitControllerTest
    {
        TransactionScope scope;
        
        private UnitController _unitController;
        private int count;
        private int unitId;

        private IUnitService _unitService;
        private IUnitRepository _unitRepository;

        [SetUp]
        public void SetUp()
        {
            scope = new TransactionScope();
            _unitRepository = new UnitRepository();
            _unitService = new UnitService(_unitRepository);
            _unitController = new UnitController(_unitService);
        }

        [TearDown]
        public void TearDown()
        {
            scope.Dispose();
        }

        [Test]
        public void Query_Not_Null()
        {
            ActionResult<OutputDtoAddUnit> unitsList=_unitController.Query();
            Assert.IsNotNull(unitsList);
        }
    }
}