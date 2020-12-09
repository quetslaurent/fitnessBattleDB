using System;
using System.Collections.Generic;
using System.Linq;
using Application.Repositories;
using Application.Services.Unit;
using Application.Services.Unit.Dto;
using Domain.Unit;
using NSubstitute;
using NUnit.Framework;

namespace NUnitTestCases.Application
{
    [TestFixture]
    public class UnitServiceTest
    {
        private static IUnitRepository _unitRepository = Substitute.For<IUnitRepository>();
        private IUnitFactory _unitFactory = Substitute.For<IUnitFactory>();
        private UnitService _unitService = new UnitService(_unitRepository);

        private static IEnumerable<IUnit> getUnitList()
        {
            Unit[] units = { new Unit("cm") };
            IEnumerable <IUnit> list= units;
            return list;
        }
        
        //QUERY

        [Test]
        public void Query_NotNull()
        {
            _unitRepository.Query().Returns(getUnitList());
            var res = _unitService.Query();
            Assert.NotNull(res);
        }
        
        [Test]
        public void Query_AreSame()
        {
            _unitRepository.Query().Returns(getUnitList());
            var res = _unitService.Query();
            
            OutputDtoQueryUnit[] outputDtoQueryUnits = { new OutputDtoQueryUnit("cm") };
            IEnumerable<OutputDtoQueryUnit> expected = outputDtoQueryUnits;
            Assert.IsTrue(res.SequenceEqual(expected));
        }
        
        [Test]
        public void Query_AreNotSame()
        {
            _unitRepository.Query().Returns(getUnitList());
            var res = _unitService.Query();
            
            OutputDtoQueryUnit[] outputDtoQueryUnits = { new OutputDtoQueryUnit("not cm") };
            IEnumerable<OutputDtoQueryUnit> expected = outputDtoQueryUnits;
            Assert.IsFalse(res.SequenceEqual(expected));
        }
        
        
        //CREATE

        [Test]
        public void Create_InputDtoAddUnit_AreSame()
        {
            
            var input= new InputDtoAddUnit("km");
            _unitFactory.CreateFromType(input.Type).Returns(new Unit(input.Type));
            var iunit = _unitFactory.CreateFromType(input.Type);
            _unitRepository.Query().Returns(getUnitList());
            _unitRepository.Create(iunit).Returns(new Unit(input.Type));
            
            var res = _unitService.Create(input);
            
            var expected = new OutputDtoAddUnit("km");

            Assert.AreEqual(expected, res);

        }
        
        
        //EXCEPTION already in DB
        
        [Test]
        public void Create_InputDtoAddUnit_ThrowsAlreadyInDBException()
        {
            var input= new InputDtoAddUnit("cm");
            _unitFactory.CreateFromType(input.Type).Returns(new Unit(input.Type));
            _unitRepository.Query().Returns(getUnitList());
            
            var exception = Assert.Throws<Exception>(() => _unitService.Create(input));
            Assert.AreEqual("Unit already in database",exception.Message);
        }
    }
}