using blazor_test.Features.Questions;

public class LabelInfo {
    public string Text { get; set; } = "Indefinido";
    public string RelatedButtonStyle { get; set; } = "btn";
}

public static class LabelParser{

    public static LabelInfo ParseLabel(LabelEnum labelEnum){
        return labelEnum switch
        {
            LabelEnum.Negative => new LabelInfo { Text = "Negativo", RelatedButtonStyle = "btn btn-danger"},
            LabelEnum.Neutral => new LabelInfo { Text = "Neutro", RelatedButtonStyle = "btn btn-secondary"},
            LabelEnum.Positive => new LabelInfo { Text = "Positivo", RelatedButtonStyle = "btn btn-success"},
            _ => new LabelInfo { Text = "Indefinido", RelatedButtonStyle = "btn"}
        };
    }

}