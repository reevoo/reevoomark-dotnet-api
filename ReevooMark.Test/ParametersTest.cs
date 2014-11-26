using System;
using NUnit.Framework;
using Rhino.Mocks;
using System.Collections.Generic;

namespace ReevooMark.Test
{
    [TestFixture()]
    public class ParametersTest
    {
        Parameters _subject;

        [SetUp]
        public void setup() {
            _subject = new Parameters(
                "trkref", "REV",
                "foo", "bar",
                "empty", "",
                "another_empty", null
            );
        }

        [Test]
        public void TestConstructorInitialization() {
            Assert.AreEqual(_subject.Count, 4);
            Assert.AreEqual(_subject["trkref"], "REV");
            Assert.AreEqual(_subject["foo"], "bar");
            Assert.AreEqual(_subject["empty"], "");
            Assert.AreEqual(_subject["another_empty"], null);
        }

        [Test]
        public void TestConstructorAlias() {
            Parameters same = new Parameters() {
                { "trkref", "REV" },
                { "foo", "bar" },
                { "empty", "" },
                { "another_empty", null },
            };

            Assert.AreEqual(_subject.Count, same.Count);

            foreach (KeyValuePair<string, string> pair in _subject) {
                Assert.AreEqual(pair.Value, same[pair.Key]);
            }
        }

        [Test]
        public void TestToString() {
            Assert.AreEqual(_subject.ToString(), "[Parameters(trkref=REV&foo=bar)]");
        }

        [Test]
        public void TestToQueryString() {
            Assert.AreEqual(_subject.ToQueryString(), "trkref=REV&foo=bar");
        }

        [Test]
        public void TestCompact() {
            Parameters compact = _subject.Compact();

            Assert.AreEqual(compact.Count, 2);
            Assert.AreEqual(compact["trkref"], "REV");
            Assert.AreEqual(compact["foo"], "bar");
        }

        [Test]
        public void TestEqualsCompact() {
            Assert.IsTrue(_subject.Equals(_subject.Compact()));
        }

        [Test]
        public void TestEqualsOther() {
            Parameters other = new Parameters() {
                { "different_empty", "" },
                { "foo", "bar" },
                { "trkref", "REV" },
            };
            Assert.IsTrue(_subject.Equals(other));
            Assert.IsTrue(other.Equals(_subject));
        }
    }
}