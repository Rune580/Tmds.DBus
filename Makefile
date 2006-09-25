all: NDesk.DBus.dll

BUS_SOURCES=Address.cs AssemblyInfo.cs Connection.cs Authentication.cs Protocol.cs Message.cs MessageFilter.cs MessageReader.cs MessageWriter.cs Server.cs Transport.cs Wrapper.cs
#UNIX_SOURCES=UnixMonoTransport.cs
UNIX_SOURCES=UnixNativeTransport.cs
CLR_SOURCES=DBus.cs Introspection.cs DProxy.cs Signature.cs

NDesk.DBus.dll: REFS=Mono.Posix

NDesk.DBus.dll: CSFLAGS=-d:PROTO_REPLY_SIGNATURE

NDesk.DBus.dll: $(BUS_SOURCES) $(UNIX_SOURCES) $(CLR_SOURCES)


include ../include.mk
