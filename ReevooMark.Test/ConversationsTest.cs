using NUnit.Framework;
using System;
using Moq;
using System.Web.UI;

namespace ReevooMark.Test
{
    [TestFixture()]
    public class ConversationsTest
    {
        Mock<ReevooClient> mock_client;
        Conversations conversations;

        [SetUp]
        public void setup()
        {
            this.mock_client = new Mock<ReevooClient>();
            this.conversations = new Conversations();
            this.conversations.TRKREF = "FOO";
            this.conversations.client = mock_client.Object;
        }

        public void RenderBadge(AbstractReevooMarkClientTag tag)
        {
            System.IO.StringWriter sw = new System.IO.StringWriter();
            HtmlTextWriter writer = new HtmlTextWriter(sw);
            tag.RenderControl(writer);
        }

        [Test]
        public void TestTagCallsClientWithCorrectAttributesAndTheCXEndpoint()
        {

            RenderBadge(this.conversations);
            this.mock_client.Verify(x => x.ObtainReevooMarkData("FOO", null, "http://mark.reevoo.com/reevoomark/embeddable_conversations"));

        }

        [Test]
        public void TestTagCallsClientWithCorrectAttributesAndTheCXEndpointWhenUsingLocale()
        {
            this.conversations.NumberOfReviews = "5";
            RenderBadge(this.conversations);
            this.mock_client.Verify(x => x.ObtainReevooMarkData("FOO", null, "http://mark.reevoo.com/reevoomark/5/embeddable_conversations"));

        }

        [Test]
        public void TestTagCallsClientWithCorrectAttributesAndTheCXEndpointWhenUsingNumberOfReviews()
        {
            this.conversations.Locale = "fr-FR";
            RenderBadge(this.conversations);
            this.mock_client.Verify(x => x.ObtainReevooMarkData("FOO", null, "http://mark.reevoo.com/reevoomark/fr-FR/embeddable_conversations"));

        }

        [Test]
        public void TestTagCallsClientWithCorrectAttributesAndTheCXEndpointWhenUsingLocaleAndNumberOfReviews()
        {
            this.conversations.NumberOfReviews = "5";
            this.conversations.Locale = "fr-FR";
            RenderBadge(this.conversations);
            this.mock_client.Verify(x => x.ObtainReevooMarkData("FOO", null, "http://mark.reevoo.com/reevoomark/fr-FR/5/embeddable_conversations"));

        }
    }
}

