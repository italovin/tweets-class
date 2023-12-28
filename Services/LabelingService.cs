using blazor_test.Models;
using blazor_test.Repositories;

namespace blazor_test.Services;

public class LabelingService(LabelingRepository labelingRepository){
    private readonly LabelingRepository _labelingRepository = labelingRepository;

    public void SendLabelings(List<Labeling> labelings){
        _labelingRepository.LabelPhrasesList(labelings);
    }
}