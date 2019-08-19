
namespace ContactManagement.Test.Unit.Controller
{
    using ContactManagement.Domain.Interfaces;
    using Moq;

    public class ContactControllerTests : TestBase
    {
        #region Fields

        private readonly Mock<IContactEngine> _contactEngine;
        //private Mock<IContactRepository> _contactRepository;
        private BaseMockData _mockData;

        #endregion

        #region "Constructor"

        public ContactControllerTests()
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
