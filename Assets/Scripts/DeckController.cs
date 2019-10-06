using Assets.Scripts;
using System.Collections.Generic;
using UnityEngine;

public class DeckController : MonoBehaviour
{
    public GameObject Card; 
    public static List<GameObject> CardsList; 
    public Sprite CommonCard;
    public Sprite UncommonCard;
    public Sprite RareCard;
    public Sprite MythicCard;
    public Sprite FoilTexture;
    public GameObject CarddexPopulateGrid;

    public PlayerController PlayerController;

    public List<string> Nouns;
    public List<string> Adjectives;

    private int totalCards = 150;

    void Awake()
    {
        CardsList = new List<GameObject>();
        InitNouns();
        InitAdjectives();

        PlayerController = GameObject.FindWithTag("PlayerGO").GetComponent<PlayerController>();
        DontDestroyOnLoad(this);
    }

    public static List<GameObject> GetStarterCards()
    {
        var starterCards = new List<GameObject>();

        //starterCards.Add(GetCard(RarityEnum.Common, false, 0));

        for(int i = 0; i < 9; i++)
        {
            starterCards.Add(GetCard(RarityEnum.Common));
        }

        return starterCards;
    }

    public static GameObject GetRandomCard()
    {
        var rarityCounter = Random.Range(0, 142);
        RarityEnum rarity = RarityEnum.Common;
        if (rarityCounter <= 100)
            rarity = RarityEnum.Common;
        else if (rarityCounter > 100 && rarityCounter <= 130)
            rarity = RarityEnum.Uncommon;
        else if (rarityCounter > 130 && rarityCounter <= 140)
            rarity = RarityEnum.Rare;
        else if (rarityCounter > 140 && rarityCounter <= 142)
            rarity = RarityEnum.Mythic;

        return GetCard(rarity, true);
    }

    public static GameObject GetCard(RarityEnum rarityEnum = RarityEnum.Common, bool withFoil = true, int index = -1)
    {
        GameObject card;

        //if (index > -1) //TODO add cards by their number
        //{
        //    card = CardsList.FirstOrDefault(x => x.GetComponent<CardController>().Number == index+1);
        //    card.GetComponent<CardController>().Discover();
        //    return card;
        //}

        if (rarityEnum == RarityEnum.Common)
        {
            int range = Random.Range(0, 79) * 2;
            if (withFoil)
                if(Random.Range(0, 24) == 24)
                    range=+1;
            card = CardsList[range];
            card.GetComponent<CardController>().Discover();
            return card;
        }
        if (rarityEnum == RarityEnum.Uncommon)
        {
            int range = Random.Range(80, 119) * 2;
            if (withFoil)
                if (Random.Range(0, 24) == 24)
                    range = +1;
            card = CardsList[range];
            card.GetComponent<CardController>().Discover();
            return card;
        }
        if (rarityEnum == RarityEnum.Rare)
        {
            int range = Random.Range(120, 139) * 2;
            if (withFoil)
                if (Random.Range(0, 24) == 24)
                    range = +1;
            card = CardsList[range];
            card.GetComponent<CardController>().Discover();
            return card;
        }
        if (rarityEnum == RarityEnum.Mythic)
        {
            int range = Random.Range(140, 149) * 2;
            if (withFoil)
                if (Random.Range(0, 24) == 24)
                    range = +1;
            card = CardsList[range];
            card.GetComponent<CardController>().Discover();
            return card;
        }

        return CardsList[0];
    }

    #region Init

    public void GenerateInitialCardSet()
    {
        if (CardsList == null)
            CardsList = new List<GameObject>();

        var name = "Start with nothing";
        var card1 = Instantiate(Card, CarddexPopulateGrid.gameObject.transform);
        var card2 = Instantiate(Card, CarddexPopulateGrid.gameObject.transform);
        var cardController1 = card1.GetComponent<CardController>();
        cardController1.Discover();
        var gameObject = Instantiate(card1, PlayerController.InventoryPopulateGrid.transform);

        gameObject.GetComponent<CardController>().Initialize(name, 1, RarityEnum.Common, CommonCard);//TODO remove from this method
        PlayerController.CardDeck.Add(gameObject);
        PlayerController.UpdateDeckLevel(gameObject);

        var cardController2 = card2.GetComponent<CardController>();
        cardController1.Initialize(name, 1, RarityEnum.Common, CommonCard);
        cardController2.Initialize(name, 1, RarityEnum.Common, CommonCard, false, true);



        for (int i = 2; i <= totalCards; i++)
        {
            name = CreateCardName();
            card1 = Instantiate(Card, CarddexPopulateGrid.gameObject.transform);
            card2 = Instantiate(Card, CarddexPopulateGrid.gameObject.transform);
            cardController1 = card1.GetComponent<CardController>();
            cardController2 = card2.GetComponent<CardController>();
            if (i <= 80) {
                cardController1.Initialize(name, i, RarityEnum.Common, CommonCard);
                cardController2.Initialize(name, i, RarityEnum.Common, CommonCard, false, true);
            }
            else if (i > 80 && i <=120)
            {
                cardController1.Initialize(name, i, RarityEnum.Uncommon, UncommonCard);
                cardController2.Initialize(name, i, RarityEnum.Uncommon, UncommonCard, false, true);
            }
            else if (i > 120 && i <=140)
            {
                cardController1.Initialize(name, i, RarityEnum.Rare, RareCard);
                cardController2.Initialize(name, i, RarityEnum.Rare, RareCard, false, true);
            }
            else if (i > 140 && i <=150)
            {
                cardController1.Initialize(name, i, RarityEnum.Mythic, MythicCard);
                cardController2.Initialize(name, i, RarityEnum.Mythic, MythicCard, false, true);
            }

            CardsList.Add(card1);
            CardsList.Add(card2);
        }
    }

    private string CreateCardName()
    {
        var nounIndex = Random.Range(0, Nouns.Count);
        var adjectiveIndex = Random.Range(0, Adjectives.Count);
        var name =  Adjectives[adjectiveIndex] + " " + Nouns[nounIndex];
        Nouns.RemoveAt(nounIndex);
        Adjectives.RemoveAt(adjectiveIndex);
        return name;
    }

    private void InitAdjectives()
    {
        Adjectives = new List<string>
        {
            "abnormal", "absent-minded", "adventurous", "affectionate", "agile", "agreeable", "alert", "amazing", "ambitious", "amiable", "amusing", "analytical", "angelic", "apathetic", "apprehensive", "ardent", "artificial", "artistic", "assertive", "attentive", "average", "awesome", "awful", "balanced", "beautiful", "beneficent", "blue", "blunt", "boisterous", "brave", "bright", "brilliant", "buff", "callous", "candid", "cantankerous", "capable", "careful", "careless", "caustic", "cautious", "charming", "cheerful", "chic", "childish", "childlike", "churlish", "circumspect", "civil", "clean", "clever", "clumsy", "coherent", "cold", "competent", "composed", "conceited", "condescending", "confident", "confused", "conscientious", "considerate", "content", "cool", "cool-headed", "cooperative", "cordial", "courageous", "cowardly", "crabby", "crafty", "cranky", "crass", "critical", "cruel", "curious", "cynical", "dainty", "decisive", "deep", "deferential", "deft", "delicate", "delightful", "demonic", "demure", "dependent", "depressed", "devoted", "dextrous", "diligent", "direct", "dirty", "disagreeable", "discerning", "discreet", "disruptive", "distant", "distraught", "distrustful", "dowdy", "dramatic", "dreary", "drowsy", "drugged", "drunk", "dull", "dutiful", "eager", "earnest", "easy-going", "efficient", "egotistical", "elfin", "emotional", "energetic", "enterprising", "enthusiastic", "evasive", "even-tempered", "exacting", "excellent", "excitable", "experienced", "fabulous", "fastidious", "ferocious", "fervent", "fiery", "flabby", "flaky", "flashy", "frank", "friendly", "funny", "fussy", "generous", "gentle", "gloomy", "glutinous", "good", "grave", "great", "groggy", "grouchy", "guarded", "hateful", "hearty", "helpful", "hesitant", "hot-headed", "hypercritical", "hysterical", "idiotic", "idle", "illogical", "imaginative", "immature", "immodest", "impatient", "imperturbable", "impetuous", "impractical", "impressionable", "impressive", "impulsive", "inactive", "incisive", "incompetent", "inconsiderate", "inconsistent", "indefatigable", "independent", "indiscreet", "indolent", "industrious", "inexperienced", "insensitive", "inspiring", "intelligent", "interesting", "intolerant", "inventive", "irascible", "irritable", "irritating", "jocular", "jovial", "joyous", "judgmental", "keen", "kind", "lame", "lazy", "lean", "leery", "lethargic", "level-headed", "listless", "lithe", "lively", "local", "logical", "long-winded", "lovable", "love-lorn", "lovely", "maternal", "mature", "mean", "meddlesome", "mercurial", "methodical", "meticulous", "mild", "miserable", "modest", "moronic", "morose", "motivated", "musical", "naive", "nasty", "natural", "naughty", "negative", "nervous", "noisy", "normal", "nosy", "numb", "obliging", "obnoxious", "old-fashioned", "one-sided", "orderly", "ostentatious", "outgoing", "outspoken", "passionate", "passive", "paternal", "paternalistic", "patient", "peaceful", "peevish", "pensive", "persevering", "persnickety", "petulant", "picky", "plain", "plain-speaking", "playful", "pleasant", "plucky", "polite", "popular", "positive", "powerful", "practical", "prejudiced", "pretty", "proficient", "proud", "provocative", "prudent", "punctual", "quarrelsome", "querulous", "quick", "quick-tempered", "quiet", "realistic", "reassuring", "reclusive", "reliable", "reluctant", "resentful", "reserved", "resigned", "resourceful", "respected", "respectful", "responsible", "restless", "revered", "ridiculous", "sad", "sassy", "saucy", "sedate", "self-assured", "selfish", "sensible", "sensitive", "sentimental", "serene", "serious", "sharp", "short-tempered", "shrewd", "shy", "silly", "sincere", "sleepy", "slight", "sloppy", "slothful", "slovenly", "slow", "smart", "snazzy", "sneering", "snobby", "sober", "somber", "sophisticated", "soulful", "soulless", "sour", "spirited", "spiteful", "stable", "staid", "steady", "stern", "stoic", "striking", "strong", "stupid", "sturdy", "subtle", "sulky", "sullen", "supercilious", "superficial", "surly", "suspicious", "sweet", "tactful", "tactless", "talented", "testy", "thinking", "thoughtful", "thoughtless", "timid", "tired", "tolerant", "touchy", "tranquil", "ugly", "unaffected", "unbalanced", "uncertain", "uncooperative", "undependable", "unemotional", "unfriendly", "unguarded", "unhelpful", "unimaginative", "unmotivated", "unpleasant", "unpopular", "unreliable", "unsophisticated", "unstable", "unsure", "unthinking", "unwilling", "venal", "versatile", "vigilant", "volcanic", "vulnerable", "warm", "warmhearted", "wary", "watchful", "weak", "well-behaved", "well-developed", "well-intentioned", "well-respected", "well-rounded", "willing", "wonderful", "zealos", "fresh", "open", "animated", "loving", "sympathetic", "encouraging", "supportive", "hopeful", "sarcastic", "narcissistic", "heavy", "bitter", "foolish", "disgruntled", "hurtful", "disgusted", "irritated", "oppressive", "anxious", "horrified", "annoyed", "sick", "guilty", "downcast", "overbearing", "involved", "sardonic", "religious", "political", "secular", "bashful", "democratic", "republican", "mysterious", "conservative", "liberal", "quizzical", "secretive", "happy", "amazed", "free", "excited", "bold", "gorgeous", "attractive", "better", "calm", "festive", "jolly", "optimistic", "ngry", "sadistic", "moody", "pessimistic", "chilly", "thirsty", "evil", "terrible", "dreadful", "dumb", "pbeat", "joyful", "appreciative", "contented", "jubilant", "aggravated", "mad", "grumpy", "tearful"
        };
    }

    private void InitNouns()
    {
        Nouns = new List<string>
        {
            "Abracadabra","Alchemy","Amulet","Apparition","Apprentice","Attraction","Battling","Beast","Berserk","Bewitch","Black cat","Brew","Captivate","Cards","Cast","Cauldron","Cave","Chalice","Charisma","Charm","Chimerical","Clairvoyant","Complexity","Conjure","Conquer","Conspirator","Coven","Creature","Crow","Crystal ball","Curious","Curse","Dark","Darkness","Death","Disappearance","Distraction","Dose","Dragon","Dread","Dream","Dwarf","Elf","Emblazoned","Empire","Enchant","Encounter","Exorcist","Experience","Fairy","Fairy tale","Familiar","Fantastic","Fantasy","Flinch","Focus","Folklore","Force","Forehead","Fortune-telling","Frighten","Garb","Ghost","Giant","Gnome","Goblin","Gowns","Graveyard","Grief","Grotesque","Gryphon","Hag","Harbinger","Herbs","Hero","Hocus-pocus","Illusion","Imagination","Immortality","Imp","Incantation","Investigate","Invisible","Jargon","Journey","Jug","Karma","Keepsake","Kettle","Kingdom","Kismet","Legend","Legerdemain","Lightening bolt","Loiter","Lore","Loss","Lucky","Lunar","Magic","Magic carpet","Magical","Magician","Majesty","Make believe","Malevolence","Medieval","Medium","Midnight","Mischievous","Misdirection","Monster","Moon","Musings","Mysterious","Mystical","Myth","Mythical","Necromancer","Necromancy","Nemesis","Newt","Obsession","Ogre","Open sesame","Oracle","Owl","Pain","Parchment","Performance","Petrify","Phoenix feather","Pixie dust","Poisonous","Pot","Potent","Potion","Powder","Power","Practice","Presto chango","Prey","Profound","Prophecy","Prophet","Prowl","Psychic","Quail","Quake","Quest","Quiver","Rabbits","Raconteur","Realism","Realm","Reign","Repel","Reverberate","Robe","Rule","Rune","Sage","Scar","Scare","Scroll","Seer","Serious","Shadow","Shaman","Soothsayer","Sorcerer","Sorcery","Specter","Spell","Spellbound","Spider","Spinning amulet","Spirit","Stars","Story","Success","Supernatural","Superstition","Survivor","Tale","Talisman","Terror","Theme","Torch","Tragic","Transformation","Trauma","Tremors","Tricks","Troll","Unbelievable","Unflinching","Unicorn","Unique","Unusual","Valiant","Valor","Vampire","Vanish","Venomous","Vicious","Victory","Visionary","Void","Voldemort","Wand","Ward","Warlock","Watchful","Weird","Werewolf","Whine","Whisk","Whispering","Wicked","Willies","Wince","Wisdom","Witch","Wizardry","Worry","Worship","Xanadu","Yearning","Youth","Yowl","Zap zealous","Zigzag","Zounds"
        };
    }

    #endregion
}