using System;

namespace ControlVee.DesignPattern.Structural.Adapter
{
    /// <summary>
    /// https://www.dofactory.com/net/adapter-design-pattern
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }

    class Compound
    {
        protected string _chemical;
        protected float _biolingPoint;
        protected float _meltingPoint;
        protected double _molecularWeight;
        protected string _molecularFormula;

        public Compound(string chemical)
        {
            this._chemical = chemical;
        }

        public virtual void Display()
        {
            Console.WriteLine($"\nCompound is: {_chemical}");
        }
    }

    /// <summary>
    /// Adapter.
    /// </summary>
    class RichCompound : Compound
    {
        private ChemicalDataBank _bank;
        public RichCompound(string name) : base (name)
        {

        }

        public override void Display()
        {
            // Adaptee.
            _bank = new ChemicalDataBank();

            _biolingPoint = _bank.GetCriticalPoint(_chemical, "B");
            _meltingPoint = _bank.GetCriticalPoint(_chemical, "M");
            _molecularWeight = _bank.GetMolecularWeight(_chemical);
            _molecularFormula = _bank.GetMolecularStructure(_chemical);

            base.Display();
        }
    }

    /// <summary>
    /// Adaptee.
    /// </summary>
    class ChemicalDataBank
    {
        // Databank "legacy API".
        public float GetCriticalPoint(string compound, string point)
        {
            // Melting point.
            if (point == "M")
            {
                switch (compound.ToLower())
                {
                    case "water": return 0.0f;
                    case "benzene": return 5.5f;
                    case "ethanol": return -114.1f;
                    default: return 0f;
                }
            }
            // Boiling point.
            else
            {
                switch (compound.ToLower())
                {
                    case "water": return 100.0f;
                    case "benzene": return 80.1f;
                    case "ethanol": return 78.3f;
                    default: return 0f;
                }
            }
        }

        public double GetMolecularWeight(string compound)
        {
            switch (compound.ToLower())
            {
                case "water": return 18.015;
                case "benzene": return 78.1134;
                case "ethanol": return 46.0688;
                default: return 0d;
            }
        }

        public string GetMolecularStructure(string compound)
        {
            switch (compound.ToLower())
            {
                case "water": return "H20";
                case "benzene": return "C6H6";
                case "ethanol": return "C2H5OH";
                default: return "";
            }
        }
    }
}
