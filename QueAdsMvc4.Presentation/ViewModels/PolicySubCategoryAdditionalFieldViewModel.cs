
namespace QueAdsMvc4.Presentation.ViewModels
{
    public class PolicySubCategoryAdditionalFieldViewModel
    {
        public int? Id { get; set; }
        public int? Policies_Id { get; set; }
        public int SubCategoryAdditionalFields_Id { get; set; }
        public int SubCategories_Id { get; set; }
        public string FieldName { get; set; }
        public string ChildFieldName { get; set; }
        public string ParentFieldName { get; set; }
        public string ControlName { get; set; }
        public string DisplayText { get; set; }
        public string DataType { get; set; }
        public string ControlType { get; set; }
        public int SortOrder { get; set; }
        public bool RequiredInd { get; set; }
        public string Value { get; set; }
    }
}
