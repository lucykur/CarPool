using System.Linq;
using Nancy;
using Nancy.Testing;
using NUnit.Framework;

namespace Carpool.Tests
{
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
        public void Should_successfully_redirect_and_set_cookie_when_user_is_authenticated()
        {
            var result = _browser.Post("/login", with =>
            {
                with.HttpRequest();
                with.FormValue("username", "demo");
                with.FormValue("password", "demo");
            });

            Assert.AreEqual(1, result.Cookies.Count());
            Assert.AreEqual(HttpStatusCode.SeeOther, result.StatusCode);
        }

        [Test]
        public void Should_successfully_redirect_and_not_set_cookie_when_user_credentials_are_not_provided()
        {
            var result = _browser.Post("/login", with => with.HttpRequest());

            Assert.AreEqual(0, result.Cookies.Count());
            Assert.AreEqual(HttpStatusCode.SeeOther, result.StatusCode);
        }


        [Test]
        public void Should_successfully_redirect_and_not_set_cookie_when_user_credentials_are_invalid()
        {
            var result = _browser.Post("/login", with =>
            {
                with.HttpRequest();
                with.FormValue("username", "demo");
                with.FormValue("password", "1234");
            });

            Assert.AreEqual(0, result.Cookies.Count());
            Assert.AreEqual(HttpStatusCode.SeeOther, result.StatusCode);
        }

    }
}
