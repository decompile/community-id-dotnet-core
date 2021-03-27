using System;
using System.Net;
using System.Security.Cryptography;

namespace CommunityID
{
    public class CommunityIDGenerator
    {
        const string v1 = "1:";
        public enum Protocol {
            ICMP = 1,
            TCP = 6,
            UDP = 17,
            RSVP = 46,
            ICMP6 = 58,
            SCTP = 132
        }
                
        public string community_id_v1(IPAddress saddr, IPAddress daddr, UInt16? sport, UInt16? dport, Protocol proto, UInt16 seed = 0) {
            
            byte[] tuple;

            if ((sport == null && dport != null) || (sport != null && dport == null))
            {
                throw new ArgumentNullException("Source and destination port values must be both either valid or null");
            }

            //If source address is larger switch order
            if (ipCompare(saddr,daddr) > 0)
            {
                IPAddress tmpAddr = saddr;
                saddr = daddr;
                daddr = tmpAddr;

                if (sport != null && dport != null)
                {
                    UInt16 tmpPort = (UInt16)sport;
                    sport = dport;
                    dport = tmpPort;
                }
            }

            //convert params to bytes
            byte[] byteseed = BitConverter.GetBytes(seed);
            byte[] bytesaddr = saddr.GetAddressBytes();
            byte[] bytedaddr = daddr.GetAddressBytes();

            if (sport is null || dport is null)
            {
                tuple = new byte[bytesaddr.Length + bytedaddr.Length + 4];               
            }
            else
            {
                byte[] bytesport = BitConverter.GetBytes((UInt16)sport);
                Array.Reverse(bytesport);
                byte[] bytesdport = BitConverter.GetBytes((UInt16)dport);
                Array.Reverse(bytesdport);

                tuple = new byte[bytesaddr.Length + bytedaddr.Length + 8];
                Buffer.BlockCopy(bytesport, 0, tuple, bytesaddr.Length + bytedaddr.Length + 4, 2);
                Buffer.BlockCopy(bytesdport, 0, tuple, bytesaddr.Length + bytedaddr.Length + 6, 2);
            }

            Buffer.BlockCopy(byteseed, 0, tuple, 0, 2);
            Buffer.BlockCopy(bytesaddr, 0, tuple, 2, bytesaddr.Length);
            Buffer.BlockCopy(bytedaddr, 0, tuple, bytesaddr.Length + 2, bytedaddr.Length);
            Buffer.BlockCopy(new byte[] { (byte)proto }, 0, tuple, bytesaddr.Length + bytedaddr.Length + 2, 1);
            Buffer.BlockCopy(new byte[] { 0 }, 0, tuple, bytesaddr.Length + bytedaddr.Length + 3, 1);

            return v1 + Convert.ToBase64String((getHash(tuple)));
            
        }

        public string community_id_v1(IPAddress saddr, IPAddress daddr, int sport, int dport, int proto, int seed = 0)
        {
            Protocol innerProtocol;
            try
            {
                innerProtocol = (CommunityIDGenerator.Protocol)proto;
            }catch(Exception ex)
            {
                throw new ArgumentException("protocol value is unsupported", ex);
            }
            return community_id_v1(saddr, daddr, ConvertToPortNumber( sport), ConvertToPortNumber( dport), innerProtocol, ConvertToPortNumber( seed ));
        }
        

        public string community_id_v1(String saddr, String daddr, UInt16 sport, UInt16 dport, Protocol proto, UInt16 seed = 0)
        {
            return community_id_v1(IPAddress.Parse(saddr), IPAddress.Parse(daddr), sport, dport, proto, seed);
        }

        private byte[] getHash(byte[] tuple)
        {
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                var hash = sha1.ComputeHash(tuple);
                return hash;
            }
        }

        private int ipCompare(IPAddress ip1, IPAddress ip2)
        {
            if (ip1.AddressFamily.CompareTo(ip2.AddressFamily )== 0){
                byte[] tmp1 = ip1.GetAddressBytes();
                byte[] tmp2 = ip2.GetAddressBytes();
                for (int i = 0; i < tmp1.Length; i++)
                {
                    if (tmp1[i] > tmp2[i]) return 1;
                    if (tmp1[i] < tmp2[i]) return -1;
                }
                return 0;
            }
            else
            {
                if (ip1.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6) return 1;
            }
            return -1;
        }

        private ushort ConvertToPortNumber(int number)
        {
            if (number < 0)
            {
                throw new ArgumentException("port value must be a positive int");
            }

            ushort result;
            try
            {
                result = Convert.ToUInt16(number);
            }
            catch (OverflowException)
            {
                throw new OverflowException("Parameter value out of range: " + number);
            }
            return result;
        }
    }
}
