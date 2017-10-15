using System;
using NUnit.Framework;
using Tiresias.ModelMapper;

namespace Tiresias.ModelWrapper.Test
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Test1()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddMapping<Input, Output>(input => new Output
                {
                    s1 = input.s1,
                    s2 = input.s3,
                    s3 = input.s2
                });
            });

            var output = Mapper.Map<Input, Output>(new Input
            {
                s1 = "s1",
                s2 = "s2",
                s3 = "s3",
            });

            Assert.That(output.s1, Is.EqualTo("s1"));
            Assert.That(output.s2, Is.EqualTo("s3"));
            Assert.That(output.s3, Is.EqualTo("s2"));
        }
    }

    public class Input
    {
        public string s1 { get; set; }
        public string s2 { get; set; }
        public string s3 { get; set; }
    }
    
    

    public class Output
    {
        public string s1 { get; set; }
        public string s2 { get; set; }
        public string s3 { get; set; }
    }
    
}