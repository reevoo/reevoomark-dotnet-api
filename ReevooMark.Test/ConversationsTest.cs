using NUnit.Framework;
using System;
using Rhino.Mocks;
using System.Web.UI;

namespace ReevooMark.Test
{
    [TestFixture()]
    public class ConversationsTest
    {
        ReevooClient mock_client;
        Conversations conversations;

        [SetUp]
        public void setup()
        {
            // Very helpful for debugging
            RhinoMocks.Logger = new Rhino.Mocks.Impl.TextWriterExpectationLogger(Console.Out);

            this.mock_client = MockRepository.GenerateMock<ReevooClient>();
            this.conversations = new Conversations();
            this.conversations.Trkref = "FOO";
            this.conversations.client = mock_client;
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
            this.mock_client.Expect(x => x.ObtainReevooMarkData(new Parameters("trkref", "FOO"), Config.BaseUri() + "reevoomark/embeddable_conversations")).Return(new ReevooMarkData());
            RenderBadge(this.conversations);
            mock_client.VerifyAllExpectations();

        }


    }
}

