using Nancy;
using Nancy.Testing;
using NUnit.Framework;

namespace Carpool.Tests
{
    [Ignore("WIP")]
    public class AuthModuleTests
    {
        private Bootstrapper _bootstrapper;
        private Browser _browser;

        [SetUp]
        public void SetUp()
        {
            _bootstrapper = new Bootstrapper();
            _browser = new Browser(_bootstrapper);
        }

        [Test]
        public void Should_successfully_redirect_when_user_is_authenticated()
        {
            var result = _browser.Post("/login", with =>
            {
                with.HttpRequest();
                with.FormValue("username", "demo");
                with.FormValue("password", "demo");
            });

            Assert.AreEqual(HttpStatusCode.SeeOther, result.StatusCode);
        }

    }
}
