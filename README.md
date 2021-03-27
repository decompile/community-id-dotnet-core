# community-id-dotnet-core
This is a C# .net core implementation of the Community ID flow hashing standard as described by [community-id-spec](https://github.com/corelight/community-id-spec).
This implentation supports IPV4 and IPV6 addresses and TCP, UDP, SCTP,ICMP and RSVP network protocols. 
Also supplied are Unit tests 

## Usage

```
CommunityIDGenerator cid = new CommunityIDGenerator();

CommunityIDGenerator.Protocol proto = CommunityIDGenerator.Protocol.TCP;
IPAddress saddr = IPAddress.Parse("128.232.110.120") ;
IPAddress daddr = IPAddress.Parse("66.35.250.204");
UInt16 sport = 34855;
UInt16 dport = 80;          

var communityid = cid.community_id_v1(saddr, daddr, sport, dport, proto);
```
result will than be given as string ```"1:LQU9qZlK+B5F3KDmev6m5PMibrg="```

Feel free to contact me with any issues or for any help.
