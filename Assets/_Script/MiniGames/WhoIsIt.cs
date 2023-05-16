using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace MiniGames
{
    public class WhoIsIt : MonoBehaviour
    {
        [SerializeField] private Button _leftButton;
        [SerializeField] private TextMeshProUGUI _leftButtonText;
        [SerializeField] private Button _rightButton;
        [SerializeField] private TextMeshProUGUI _rightButtonText;
        [SerializeField] private Image _characterPictures;

        private void OnEnable()
        {
            StartGame();
        }

        private void StartGame()
        {
            var characters = Resources.LoadAll<Character>("Characters");
            var targetCharacterNum = Random.Range(0, characters.Length);
            var otherCharacterNum = Random.Range(0, characters.Length);
            var howButton = Random.Range(0, 2);

            while (otherCharacterNum == targetCharacterNum)
            {
                otherCharacterNum = Random.Range(0, characters.Length);
            }

            var targetCharacterName = characters[targetCharacterNum].Name();
            var otherCharacterName = characters[otherCharacterNum].Name();
            
            var button = howButton == 0 ? _leftButton : _rightButton;
            var buttonText = howButton == 0 ? _leftButtonText : _rightButtonText;
            
            button.onClick.AddListener(Win);
            buttonText.text = targetCharacterName;
            
            var otherButton = howButton != 0 ? _leftButton : _rightButton;
            var botherButtonText = howButton != 0 ? _leftButtonText : _rightButtonText;
            
            otherButton.onClick.AddListener(Fail);
            botherButtonText.text = otherCharacterName;

            _characterPictures.sprite = characters[targetCharacterNum].Picture();
        }

        private void Win()
        {
            Debug.Log("Win KURWA BOBER");
        }

        private void Fail()
        {
            Debug.Log("Ya pierdole yake bidlo ebane");
        }
    }
}