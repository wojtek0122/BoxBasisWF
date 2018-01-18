using System.Collections;

namespace BoxBasisWF
{
    class DataPacket
    {
        public struct Packet
        {
            public int DataPacketID;
            public byte ID;
            public float VCCVoltage;
            public bool BasisSwitch;
            public bool TesterSwitch;
            public float CapacitorVoltage;
        } 

        private ArrayList Packets;

        public DataPacket()
        {
            Packets = new ArrayList();
        }

        public void AddPacketToArrayList(Packet p)
        {
            Packets.Add(p);
        }

        public Packet ShowPacket(int number)
        { 
            return (Packet) Packets[number];
        }
    }
}
