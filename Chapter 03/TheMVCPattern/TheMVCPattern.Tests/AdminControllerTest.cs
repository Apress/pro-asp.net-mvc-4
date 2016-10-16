using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheMVCPattern.Controllers;
using TheMVCPattern.Models;

namespace TheMVCPattern.Tests {


    [TestClass()]
    public class AdminControllerTest {


        private TestContext testContextInstance;

        public TestContext TestContext {
            get {
                return testContextInstance;
            }
            set {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion



        [TestMethod]
        public void CanChangeLoginName() {

            // Arrange (set up a scenario)
            Member bob = new Member() { LoginName = "Bob" };
            FakeMembersRepository repositoryParam = new FakeMembersRepository();
            repositoryParam.Members.Add(bob);
            AdminController target = new AdminController(repositoryParam);
            string oldLoginParam = bob.LoginName;
            string newLoginParam = "Anastasia";

            // Act (attempt the operation)
            target.ChangeLoginName(oldLoginParam, newLoginParam);

            // Assert (verify the result)
            Assert.AreEqual(newLoginParam, bob.LoginName);
            Assert.IsTrue(repositoryParam.DidSubmitChanges);
        }

        private class FakeMembersRepository : IMembersRepository {
            public List<Member> Members = new List<Member>();
            public bool DidSubmitChanges = false;

            public void AddMember(Member member) {
                throw new NotImplementedException();
            }

            public Member FetchByLoginName(string loginName) {
                return Members.First(m => m.LoginName == loginName);
            }

            public void SubmitChanges() {
                DidSubmitChanges = true;
            }
        }

        [TestMethod()]
        public void CanAddBid() {

            // Arrange - set up the scenario
            Item target = new Item();
            Member memberParam = new Member();
            Decimal amountParam = 150M;

            // Act - perform the test
            target.AddBid(memberParam, amountParam);

            // Assert - check the behavior
            Assert.AreEqual(1, target.Bids.Count());
            Assert.AreEqual(amountParam, target.Bids[0].BidAmount);
        }

        [TestMethod()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CannotAddLowerBid() {

            // Arrange
            Item target = new Item();
            Member memberParam = new Member();
            Decimal amountParam = 150M;

            // Act
            target.AddBid(memberParam, amountParam);
            target.AddBid(memberParam, amountParam - 10);
        }

        [TestMethod()]
        public void CanAddHigherBid() {

            // Arrange
            Item target = new Item();
            Member firstMember = new Member();
            Member secondMember = new Member();
            Decimal amountParam = 150M;

            // Act
            target.AddBid(firstMember, amountParam);
            target.AddBid(secondMember, amountParam + 10);

            // Assert
            Assert.AreEqual(2, target.Bids.Count());
            Assert.AreEqual(amountParam + 10, target.Bids[1].BidAmount);
        }


    }
}
