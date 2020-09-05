# QuickBuffer
A simple library for easily handling bytes and bits.

# Reading/writing buffers
QuickBuffer provides extendable classes for reading/writing byte buffers.<br>
The class BufferReader is used for reading buffers whilst BufferWriter is used for writing them.<br>
One could add additional functionality by deriving said classes.

### Writing
Let's start off by writing a buffer to read from later.

```csharp
BufferWriter writer = new BufferWriter();
writer.TextEncoding = Encoding.Unicode;

writer.WriteBool(true);
writer.WriteString("test");
writer.WriteInt(1337);

byte[] output = writer.ToArray();
``` 

### Reading
Let's now read from the buffer we just created.

```csharp
BufferReader reader = new BufferReader(output);
reader.TextEncoding = Encoding.Unicode;

bool b = reader.ReadBool();
string str = reader.ReadString(8); // ReadString() takes in an amount of bytes to read. We have to do the original length x2 because of the unicode encoding
int i = reader.ReadInt();
```

# Bits
C#'s default BitArray class can be a pain to use. QuickBuffer therefore adds the additional classes BitBuffer and BitList.

### BitBuffers
The BitBuffer class is basically a BitArray with more functionality, such as reversing the bits.

```csharp
BitBuffer buffer = new BitBuffer(new byte[] { 1, 3, 3, 7 }); // create a BitBuffer from the passed byte array
buffer.Or(new BitArray(new byte[] { 1, 2, 3, 4 })); // OR them with another byte array

byte[] output = buffer.ToBytes(); // convert the result back into a byte array
BitBuffer extractedBits = buffer.CopyBits(1, 4); // Copies 4 bits starting from an offset of 1

buffer.ToBitArray(); // converting BitBuffers into BitArrays is easy as they just wrap around them.
```

### BitLists
The BitList class is basically the same as a BitBuffer but with the extra functionality from the standard List class.

```csharp
BitList list = new BitList(new byte[] { 1, 3, 3, 7 });
list.RemoveRange(6, 7); // Remove 7 bits starting from an offset of 6

byte[] output = list.ToBytes(); // Convert the bits into a byte array
BitBuffer buffer = list.ToBitBuffer(); // Convert the list into a BitBuffer
```
