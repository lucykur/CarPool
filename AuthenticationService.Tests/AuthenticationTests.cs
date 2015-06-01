using Nancy;
using Nancy.Testing;
using Newtonsoft.Json;
using NUnit.Framework;

namespace AuthenticationService.Tests
{
    public class AuthenticationTests
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
        public void Should_return_demo_user()
        {
            var result = _browser.Get("/api/user", with =>
            {
                with.HttpRequest();
                with.Query("username", "demo");
                with.Query("password", "demo");
            });

            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);

            var user = JsonConvert.DeserializeObject<User>(result.Body.AsString());
            // Then

            Assert.AreEqual(user.Id.ToString(), "d7a169b2-5247-4ab2-ba81-1beeafe979f4");
            Assert.AreEqual(user.Username, "demo");
          
        }

        [Test]
        public void Should_return_user_not_found_for_an_valid_user_and_invalid_password()
        {

            // When
            var result = _browser.Get("/api/user", with =>
            {
                with.HttpRequest();
                with.Query("username", "demo");
                with.Query("password", "1234");
            });

            Assert.AreEqual(HttpStatusCode.NotFound, result.StatusCode);
        }

        [Test]
        public void Should_return_user_not_found_for_an_invalid_user()
        {
            var result = _browser.Get("/api/user", with =>
            {
                with.HttpRequest();
                with.Query("username", "2345");
                with.Query("password", "1234");
            });

            Assert.AreEqual(HttpStatusCode.NotFound, result.StatusCode);
        }

        [Test]
        public void Should_return_user_by_id()
        {
            // When
            var result = _browser.Get("/api/user/d7a169b2-5247-4ab2-ba81-1beeafe979f4", with => with.HttpRequest());
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);

            var user = JsonConvert.DeserializeObject<User>(result.Body.AsString());

            Assert.AreEqual(user.Id.ToString(), "d7a169b2-5247-4ab2-ba81-1beeafe979f4");
            Assert.AreEqual(user.Username, "demo");
        }
    }
}
