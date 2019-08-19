
namespace ContactManagement.Test.Unit.Engine
{
    using ContactManagement.Domain.Interfaces;
    using ContactManagement.Storage.Repository;
    using Moq;
    using Xunit;

    class ContactEngineTests : TestBase
    {
        #region Fields

        private readonly Mock<IContactEngine> _contactEngine;
        //private Mock<IContactRepository> _contactRepository;
        private BaseMockData _mockData;

        #endregion

        #region "Constructor"

        public ContactEngineTests()
        {
            _contactEngine = new Mock<IContactEngine>();
            _mockData = new BaseMockData();
        }

        #endregion

        #region "Unit Test Cases"
        //Test cases not added yet
        #endregion

    }
}