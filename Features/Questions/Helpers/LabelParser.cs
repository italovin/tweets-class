using blazor_test.Features.Questions;

public static class LabelParser{

    public static string ParseLabel(LabelEnum labelEnum){
        return labelEnum switch
        {
            LabelEnum.Negative => "Negativo",
            LabelEnum.Neutral => "Neutro",
            LabelEnum.Positive => "Positivo",
            _ => "Indefinido"
        };
    }

}