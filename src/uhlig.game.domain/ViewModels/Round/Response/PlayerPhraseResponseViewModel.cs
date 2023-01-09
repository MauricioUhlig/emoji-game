using System;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace uhlig.game.domain.ViewModels.Round.Response
{
    public class PlayerPhraseResponseViewModel
    {
        public string Name { get; set; }
        public string Phrase { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int? WinScore { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int? TotalScore { get; set; }

        public PlayerPhraseResponseViewModel(string name, string phrase, int winScore, int totalScore)
        {
            Name = name;
            Phrase = phrase;
            WinScore = winScore;
            TotalScore = totalScore;
        }
        public PlayerPhraseResponseViewModel(string name, string phrase)
        {
            Name = name;
            Phrase = phrase;
        }
    }
}