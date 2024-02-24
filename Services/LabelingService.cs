using blazor_test.Models.ORM;
using blazor_test.Repositories;

namespace blazor_test.Services;

public class LabelingService(LabelingRepository labelingRepository){
    private readonly LabelingRepository _labelingRepository = labelingRepository;

    public void SendLabelings(List<Labeling> labelings){
        _labelingRepository.LabelPhrasesList(labelings);
    }
}