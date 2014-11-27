using NUnit.Framework;
using System;
using Rhino.Mocks;
using System.Web.UI;

namespace ReevooMark.Test
{
    [TestFixture()]
    public class ConversationsTest
    {
        ReevooClient mockedClient;
        Conversations conversations;

        [SetUp]
        public void setup()
        {
            // Very helpful for debugging
            RhinoMocks.Logger = new Rhino.Mocks.Impl.TextWriterExpectationLogger(Console.Out);

            mockedClient = MockRepository.GenerateMock<ReevooClient>();
            conversations = new Conversations();
            conversations.Trkref = "FOO";
            conversations.client = mockedClient;
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
            mockedClient.Expect(x => x.ObtainReevooMarkData(new Parameters("trkref", "FOO"), Config.BaseUri() + "reevoomark/embeddable_conversations")).Return(new ReevooMarkData());
            RenderBadge(conversations);
            mockedClient.VerifyAllExpectations();

        }
    }
}

