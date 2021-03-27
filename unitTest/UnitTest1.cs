using NUnit.Framework;
using System;
using System.Net;


namespace CommunityID
{
    public class Tests
    {

        CommunityIDGenerator cid;
        IPAddress saddr;
        IPAddress daddr;
       [SetUp]
        public void Setup()
        {
             cid = new CommunityID.CommunityIDGenerator();
        }


        [Test] 
        public void TCP_v4_test1()
        {
            var proto = "TCP";
            saddr = IPAddress.Parse("128.232.110.120") ;
            daddr = IPAddress.Parse("66.35.250.204");
            UInt16 sport = 34855;
            UInt16 dport = 80;
            var communityid = "1:LQU9qZlK+B5F3KDmev6m5PMibrg=";

            var resHash = cid.community_id_v1(saddr, daddr, sport, dport, (CommunityID.CommunityIDGenerator.Protocol)Enum.Parse(typeof(CommunityID.CommunityIDGenerator.Protocol),proto));
            
            Assert.AreEqual(resHash,communityid);
        }

        [Test]
        public void TCP_v4_test2()
        {
            var proto = "TCP";
            saddr = IPAddress.Parse("66.35.250.204");
            daddr = IPAddress.Parse("128.232.110.120");

            UInt16 sport = 80;
            UInt16 dport = 34855;
            var communityid = "1:LQU9qZlK+B5F3KDmev6m5PMibrg=";

            var resHash = cid.community_id_v1(saddr, daddr, sport, dport, (CommunityID.CommunityIDGenerator.Protocol)Enum.Parse(typeof(CommunityID.CommunityIDGenerator.Protocol), proto));

            Assert.AreEqual(resHash, communityid);
        }

        [Test]
        public void TCP_v4_test3()
        {
            var proto = 6;
            saddr = IPAddress.Parse("66.35.250.204");
            daddr = IPAddress.Parse("128.232.110.120");

            int sport = 80;
            int dport = 34855;
            var communityid = "1:LQU9qZlK+B5F3KDmev6m5PMibrg=";

            var resHash = cid.community_id_v1(saddr, daddr, sport, dport, proto);

            Assert.AreEqual(resHash, communityid);
        }

        [Test]
        public void TCP_v6_test1()
        {
            var proto = "TCP";
            saddr = IPAddress.Parse("2001:470:e5bf:dead:4957:2174:e82c:4887");
            daddr = IPAddress.Parse("2607:f8b0:400c:c03::1a");

            UInt16 sport = 63943 ;
            UInt16 dport = 25;
            var communityid = "1:/qFaeAR+gFe1KYjMzVDsMv+wgU4=";

            var resHash = cid.community_id_v1(saddr, daddr, sport, dport, (CommunityID.CommunityIDGenerator.Protocol)Enum.Parse(typeof(CommunityID.CommunityIDGenerator.Protocol), proto));

            Assert.AreEqual(resHash, communityid);
        }

        [Test]
        public void TCP_v6_test2()
        {
            var proto = "TCP";
            saddr = IPAddress.Parse("2607:f8b0:400c:c03::1a");
            daddr = IPAddress.Parse("2001:470:e5bf:dead:4957:2174:e82c:4887");

            UInt16 sport = 25;
            UInt16 dport = 63943;
            var communityid = "1:/qFaeAR+gFe1KYjMzVDsMv+wgU4=";

            var resHash = cid.community_id_v1(saddr, daddr, sport, dport, (CommunityID.CommunityIDGenerator.Protocol)Enum.Parse(typeof(CommunityID.CommunityIDGenerator.Protocol), proto));

            Assert.AreEqual(resHash, communityid);
        }

        [Test]
        public void UDP_v4_test1()
        {
            var proto = "UDP";
            saddr = IPAddress.Parse("192.168.1.52");
            daddr = IPAddress.Parse("8.8.8.8");
            UInt16 sport = 54585;
            UInt16 dport = 53;
            var communityid = "1:d/FP5EW3wiY1vCndhwleRRKHowQ=";

            var resHash = cid.community_id_v1(saddr, daddr, sport, dport, (CommunityID.CommunityIDGenerator.Protocol)Enum.Parse(typeof(CommunityID.CommunityIDGenerator.Protocol), proto));

            Assert.AreEqual(resHash, communityid);
        }

        [Test]
        public void UDP_v4_test2()
        {
            var proto = "UDP";
            saddr = IPAddress.Parse("8.8.8.8");
            daddr = IPAddress.Parse("192.168.1.52");
            UInt16 sport = 53;
            UInt16 dport = 54585;
            var communityid = "1:d/FP5EW3wiY1vCndhwleRRKHowQ=";

            var resHash = cid.community_id_v1(saddr, daddr, sport, dport, (CommunityID.CommunityIDGenerator.Protocol)Enum.Parse(typeof(CommunityID.CommunityIDGenerator.Protocol), proto));

            Assert.AreEqual(resHash, communityid);
        }

        [Test]
        public void RSVP_v4_test1()
        {
            var proto = "RSVP";
            saddr = IPAddress.Parse("10.1.12.1");
            daddr = IPAddress.Parse("10.1.12.2");
            UInt16? sport = null;
            UInt16? dport = null;
            var communityid = "1:KHlLkgoJW7ifUTyTSgyVfkFHzKw=";

            var resHash = cid.community_id_v1(saddr, daddr, sport, dport, (CommunityID.CommunityIDGenerator.Protocol)Enum.Parse(typeof(CommunityID.CommunityIDGenerator.Protocol), proto));

            Assert.AreEqual(resHash, communityid);
        }
        [Test]
        public void RSVP_v4_test2()
        {
            var proto = "RSVP";
            saddr = IPAddress.Parse("10.1.12.2");
            daddr = IPAddress.Parse("10.1.12.1");
            UInt16? sport = null;
            UInt16? dport = null;
            var communityid = "1:KHlLkgoJW7ifUTyTSgyVfkFHzKw=";

            var resHash = cid.community_id_v1(saddr, daddr, sport, dport, (CommunityID.CommunityIDGenerator.Protocol)Enum.Parse(typeof(CommunityID.CommunityIDGenerator.Protocol), proto));

            Assert.AreEqual(resHash, communityid);
        }

        [Test]
        public void RSVP_v4_test3()
        {
            var proto = "RSVP";
            saddr = IPAddress.Parse("1.2.3.4");
            daddr = IPAddress.Parse("5.6.7.8");
            UInt16? sport = null;
            UInt16? dport = null;
            var communityid = "1:ikv3kmf89luf73WPz1jOs49S768=";

            var resHash = cid.community_id_v1(saddr, daddr, sport, dport, (CommunityID.CommunityIDGenerator.Protocol)Enum.Parse(typeof(CommunityID.CommunityIDGenerator.Protocol), proto));

            Assert.AreEqual(resHash, communityid);
        }

        [Test]
        public void ICMP_v4_test1()
        {
            var proto = "ICMP";
            saddr = IPAddress.Parse("192.168.0.89");
            daddr = IPAddress.Parse("192.168.0.1");
            UInt16 sport = 8;
            UInt16 dport = 0;
            var communityid = "1:X0snYXpgwiv9TZtqg64sgzUn6Dk=";

            var resHash = cid.community_id_v1(saddr, daddr, sport, dport, (CommunityID.CommunityIDGenerator.Protocol)Enum.Parse(typeof(CommunityID.CommunityIDGenerator.Protocol), proto));

            Assert.AreEqual(resHash, communityid);
        }

        [Test]
        public void ICMP_v4_test2()
        {
            var proto = "ICMP";
            saddr = IPAddress.Parse("192.168.0.1");
            daddr = IPAddress.Parse("192.168.0.89");
            UInt16 sport = 0;
            UInt16 dport = 8;
            var communityid = "1:X0snYXpgwiv9TZtqg64sgzUn6Dk=";

            var resHash = cid.community_id_v1(saddr, daddr, sport, dport, (CommunityID.CommunityIDGenerator.Protocol)Enum.Parse(typeof(CommunityID.CommunityIDGenerator.Protocol), proto));

            Assert.AreEqual(resHash, communityid);
        }

        [Test]
        public void ICMP_v4_test3()
        {
            var proto = "ICMP";
            saddr = IPAddress.Parse("10.0.0.1");
            daddr = IPAddress.Parse("10.0.0.2");
            UInt16 sport = 11;
            UInt16 dport = 0;
            var communityid = "1:YHxtAirCG//0OzkcVAukqKQN9xM=";

            var resHash = cid.community_id_v1(saddr, daddr, sport, dport, (CommunityID.CommunityIDGenerator.Protocol)Enum.Parse(typeof(CommunityID.CommunityIDGenerator.Protocol), proto));

            Assert.AreEqual(resHash, communityid);
        }

        [Test]
        public void ICMP6_v6_test1()
        {
            var proto = "ICMP6";
            saddr = IPAddress.Parse("fe80::200:86ff:fe05:80da");
            daddr = IPAddress.Parse("fe80::260:97ff:fe07:69ea");
            UInt16 sport = 135;
            UInt16 dport = 136;
            var communityid = "1:dGHyGvjMfljg6Bppwm3bg0LO8TY=";

            var resHash = cid.community_id_v1(saddr, daddr, sport, dport, (CommunityID.CommunityIDGenerator.Protocol)Enum.Parse(typeof(CommunityID.CommunityIDGenerator.Protocol), proto));

            Assert.AreEqual(resHash, communityid);
        }

        [Test]
        public void ICMP6_v6_test2()
        {
            var proto = "ICMP6";
            saddr = IPAddress.Parse("fe80::260:97ff:fe07:69ea");
            daddr = IPAddress.Parse("fe80::200:86ff:fe05:80da");
            UInt16 sport = 136;
            UInt16 dport = 135;
            var communityid = "1:dGHyGvjMfljg6Bppwm3bg0LO8TY=";

            var resHash = cid.community_id_v1(saddr, daddr, sport, dport, (CommunityID.CommunityIDGenerator.Protocol)Enum.Parse(typeof(CommunityID.CommunityIDGenerator.Protocol), proto));

            Assert.AreEqual(resHash, communityid);
        }

        [Test]
        public void ICMP6_v6_test3()
        {
            var proto = "ICMP6";
            saddr = IPAddress.Parse("fe80::200:86ff:fe05:80da");
            daddr = IPAddress.Parse("fe80::260:97ff:fe07:69ea");
            UInt16 sport = 136;
            UInt16 dport = 135;
            var communityid = "1:zavyT/cezQr1fmImYCwYnMXbgck=";

            var resHash = cid.community_id_v1(saddr, daddr, sport, dport, (CommunityID.CommunityIDGenerator.Protocol)Enum.Parse(typeof(CommunityID.CommunityIDGenerator.Protocol), proto));

            Assert.AreEqual(resHash, communityid);
        }

        [Test]
        public void ICMP6_v6_test4()
        {
            var proto = "ICMP6";
            saddr = IPAddress.Parse("fe80::260:97ff:fe07:69ea");
            daddr = IPAddress.Parse("fe80::200:86ff:fe05:80da");
            UInt16 sport = 135;
            UInt16 dport = 136;
            var communityid = "1:zavyT/cezQr1fmImYCwYnMXbgck=";

            var resHash = cid.community_id_v1(saddr, daddr, sport, dport, (CommunityID.CommunityIDGenerator.Protocol)Enum.Parse(typeof(CommunityID.CommunityIDGenerator.Protocol), proto));

            Assert.AreEqual(resHash, communityid);
        }

        [Test]
        public void ICMP6_v6_test5()
        {
            var proto = "ICMP6";
            saddr = IPAddress.Parse("3ffe:501:1800:2345::2");
            daddr = IPAddress.Parse("3ffe:507:0:1:200:86ff:fe05:80da");
            UInt16 sport = 3;
            UInt16 dport = 0;
            var communityid = "1:2ObVBgIn28oZvibYZhZMBgh7WdQ=";

            var resHash = cid.community_id_v1(saddr, daddr, sport, dport, (CommunityID.CommunityIDGenerator.Protocol)Enum.Parse(typeof(CommunityID.CommunityIDGenerator.Protocol), proto));

            Assert.AreEqual(resHash, communityid);
        }

        [Test]
        public void ICMP6_v6_test6()
        {
            var proto = "ICMP6";
            saddr = IPAddress.Parse("3ffe:501:410:0:2c0:dfff:fe47:33e");
            daddr = IPAddress.Parse("3ffe:507:0:1:200:86ff:fe05:80da");
            UInt16 sport = 1;
            UInt16 dport = 4;
            var communityid = "1:hLZd0XGWojozrvxqE0dWB1iM6R0=";

            var resHash = cid.community_id_v1(saddr, daddr, sport, dport, (CommunityID.CommunityIDGenerator.Protocol)Enum.Parse(typeof(CommunityID.CommunityIDGenerator.Protocol), proto));

            Assert.AreEqual(resHash, communityid);
        }

        [Test]
        public void ICMP6_v6_test7()
        {
            var proto = "ICMP6";
            saddr = IPAddress.Parse("3ffe:507:0:1:200:86ff:fe05:80da");
            daddr = IPAddress.Parse("3ffe:501:0:1001::2");
            UInt16 sport = 128;
            UInt16 dport = 129;
            var communityid = "1:+TW+HtLHvV1xnGhV1lv7XoJrqQg=";

            var resHash = cid.community_id_v1(saddr, daddr, sport, dport, (CommunityID.CommunityIDGenerator.Protocol)Enum.Parse(typeof(CommunityID.CommunityIDGenerator.Protocol), proto));

            Assert.AreEqual(resHash, communityid);
        }

        [Test]
        public void ICMP6_v6_test8()
        {
            var proto = "ICMP6";
            saddr = IPAddress.Parse("3ffe:501:0:1001::2");
            daddr = IPAddress.Parse("3ffe:507:0:1:200:86ff:fe05:80da");
            UInt16 sport = 129;
            UInt16 dport = 128;
            var communityid = "1:+TW+HtLHvV1xnGhV1lv7XoJrqQg=";

            var resHash = cid.community_id_v1(saddr, daddr, sport, dport, (CommunityID.CommunityIDGenerator.Protocol)Enum.Parse(typeof(CommunityID.CommunityIDGenerator.Protocol), proto));

            Assert.AreEqual(resHash, communityid);
        }

        [Test]
        public void ICMP6_v6_test9()
        {
            var proto = "ICMP6";
            saddr = IPAddress.Parse("fe80::200:86ff:fe05:80da");
            daddr = IPAddress.Parse("ff02::2");
            UInt16 sport = 133;
            UInt16 dport = 134;
            var communityid = "1:hO+sN4H+MG5MY/8hIrXPqc4ZQz0=";

            var resHash = cid.community_id_v1(saddr, daddr, sport, dport, (CommunityID.CommunityIDGenerator.Protocol)Enum.Parse(typeof(CommunityID.CommunityIDGenerator.Protocol), proto));

            Assert.AreEqual(resHash, communityid);
        }

        [Test]
        public void ICMP6_v6_test10()
        {
            var proto = "ICMP6";
            saddr = IPAddress.Parse("fe80::260:97ff:fe07:69ea");
            daddr = IPAddress.Parse("ff02::1");
            UInt16 sport = 134;
            UInt16 dport = 133;
            var communityid = "1:pkvHqCL88/tg1k4cPigmZXUtL00=";

            var resHash = cid.community_id_v1(saddr, daddr, sport, dport, (CommunityID.CommunityIDGenerator.Protocol)Enum.Parse(typeof(CommunityID.CommunityIDGenerator.Protocol), proto));

            Assert.AreEqual(resHash, communityid);
        }

        [Test]
        public void SCTP_v4_test1()
        {
            var proto = "SCTP";
            saddr = IPAddress.Parse("192.168.170.8");
            daddr = IPAddress.Parse("192.168.170.56");
            UInt16? sport = 7;
            UInt16? dport = 7;
            var communityid = "1:MP2EtRCAUIZvTw6MxJHLV7N7JDs=";

            var resHash = cid.community_id_v1(saddr, daddr, sport, dport, (CommunityID.CommunityIDGenerator.Protocol)Enum.Parse(typeof(CommunityID.CommunityIDGenerator.Protocol), proto));

            Assert.AreEqual(resHash, communityid);
        }

        [Test]
        public void SCTP_v4_test2()
        {
            var proto = "SCTP";
            saddr = IPAddress.Parse("192.168.170.56");
            daddr = IPAddress.Parse("192.168.170.8");
            UInt16? sport = 7;
            UInt16? dport = 7;
            var communityid = "1:MP2EtRCAUIZvTw6MxJHLV7N7JDs=";

            var resHash = cid.community_id_v1(saddr, daddr, sport, dport, (CommunityID.CommunityIDGenerator.Protocol)Enum.Parse(typeof(CommunityID.CommunityIDGenerator.Protocol), proto));

            Assert.AreEqual(resHash, communityid);
        }

        [Test]
        public void SCTP_v4_test3()
        {
            var proto = "SCTP";
            saddr = IPAddress.Parse("192.168.170.8");
            daddr = IPAddress.Parse("192.168.170.56");
            UInt16 sport = 7;
            UInt16 dport = 80;
            var communityid = "1:jQgCxbku+pNGw8WPbEc/TS/uTpQ=";

            var resHash = cid.community_id_v1(saddr, daddr, sport, dport, (CommunityID.CommunityIDGenerator.Protocol)Enum.Parse(typeof(CommunityID.CommunityIDGenerator.Protocol), proto));

            Assert.AreEqual(resHash, communityid);
        }
    }
}