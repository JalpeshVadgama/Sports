namespace Sports.Models
{
    public class TestType :  EnumBase<TestTypeEnum>
    {
        public TestType() : base() { } //for EF
        private TestType(TestTypeEnum e) : base(e) { }

        public static implicit operator TestType(TestTypeEnum @enum) => new TestType(@enum);
        public static implicit operator TestTypeEnum(TestType classObj) => (TestTypeEnum)classObj.id;
    }
}
