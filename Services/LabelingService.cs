using Models.ORM;
using Repositories;

namespace Services;

public class LabelingService(LabelingRepository labelingRepository){
    private readonly LabelingRepository _labelingRepository = labelingRepository;

    public void SendLabelings(List<Labeling> labelings){
        _labelingRepository.LabelPhrasesList(labelings);
    }
}