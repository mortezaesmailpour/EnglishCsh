namespace English.Verbs;

public class Irregulars
{
    //public static Verb See = new PresentSimple("see", "saw", "seen");
    
    public static List<PresentSimple> List = new List<PresentSimple>()
    {
        new("arise", "arose", "arisen"),
        new("awake", "awoke", "awoken"),
        new("bear", "bore", "born"),
        new("beat", "beat", "beaten"),
        new("become", "became", "become"),
        new("begin", "began", "begun"),
        new("bend", "bent", "bent"),
        new("bet", "bet", "bet"),
        new("bind", "bound", "bound"),
        new("bite", "bit", "bitten"),
        new("bleed", "bled", "bled"),
        new("blow", "blew", "blown"),
        new("break", "broke", "broken"),
        new("breed", "bred", "bred"),
        new("bring", "brought", "brought"),
        new("broadcast", "broadcast", "broadcast"),
        new("build", "built", "built"),
        new("burn", "burnt", "burnt"),
        new("burst", "burst", "burst"),
        new("buy", "bought", "bought"),
        new("catch", "caught", "caught"),
        new("choose", "chose", "chosen"),
        new("cling", "clung", "clung"),
        new("come", "came", "come"),
        new("cost", "cost", "cost"),
        new("creep", "crept", "crept"),
        new("cut", "cut", "cut"),
        new("deal", "dealt", "dealt"),
        new("dig", "dug", "dug"),
        new("do", "did", "done"),
        new("draw", "drew", "drawn"),
        new("dream", "dreamt", "dreamt"),
        new("drink", "drank", "drunk"),
        new("drive", "drove", "driven"),
        new("eat", "ate", "eaten"),
        new("fall", "fell", "fallen"),
        new("feed", "fed", "fed"),
        new("feel", "felt", "felt"),
        new("fight", "fought", "fought"),
        new("find", "found", "found"),
        new("fly", "flew", "flown"),
        new("forbid", "forbade", "forbidden"),
        new("forget", "forgot", "forgotten"),
        new("forgive", "forgave", "forgiven"),
        new("freeze", "froze", "frozen"),
        new("get", "got", "got"),
        new("give", "gave", "given"),
        new("go", "went", "gone"),
        new("grind", "ground", "ground"),
        new("grow", "grew", "grown"),
        new("hang", "hung", "hung"),
        new("have", "had", "had"),
        new("hear", "heard", "heard"),
        new("hide", "hid", "hidden"),
        new("hit", "hit", "hit"),
        new("hold", "held", "held"),
        new("hurt", "hurt", "hurt"),
        new("keep", "kept", "kept"),
        new("kneel", "knelt", "knelt"),
        new("know", "knew", "known"),
        new("lay", "laid", "laid"),
        new("lead", "led", "led"),
        new("lean", "leant", "leant"),
        new("learn", "learnt", "learnt"),
        new("leave", "left", "left"),
        new("lend", "lent", "lent"),
        new("lie", "lay", "lain"),
        new("lie", "lied", "lied"),
        new("light", "lit ", "lit"),
        new("lose", "lost", "lost"),
        new("make", "made", "made"),
        new("mean", "meant", "meant"),
        new("meet", "met", "met"),
        new("mow", "mowed", "mown"),
        new("overtake", "overtook", "overtaken"),
        new("pay", "paid", "paid"),
        new("put", "put", "put"),
        new("read", "read", "read"),
        new("ride", "rode", "ridden"),
        new("ring", "rang", "rung"),
        new("rise", "rose", "risen"),
        new("run", "ran", "run"),
        new("saw", "sawed", "sawn"),
        new("say", "said", "said"),
        new("see", "saw", "seen"),
        new("sell", "sold", "sold"),
        new("send", "sent", "sent"),
        new("set", "set", "set"),
        new("sew", "sewed", "sewn"),
        new("shake", "shook", "shaken"),
        new("shed", "shed", "shed"),
        new("shine", "shone", "shone"),
        new("shoot", "shot", "shot"),
        new("show", "showed", "shown"),
        new("shrink", "shrank", "shrunk"),
        new("shut", "shut", "shut"),
        new("sing", "sang", "sung"),
        new("sink", "sank", "sunk"),
        new("sit", "sat", "sat"),
        new("sleep", "slept", "slept"),
        new("slide", "slid", "slid"),
        new("smell", "smelt", "smelt"),
        new("sow", "sowed", "sown"),
        new("speak", "spoke", "spoken"),
        new("spell", "spelt", "spelt"),
        new("spend", "spent", "spent"),
        new("spill", "spilt", "spilt"),
        new("spit", "spat", "spat"),
        new("spread", "spread", "spread"),
        new("stand", "stood", "stood"),
        new("steal", "stole", "stolen"),
        new("stick", "stuck", "stuck"),
        new("sting", "stung", "stung"),
        new("stink", "stank", "stunk"),
        new("strike", "struck", "struck"),
        new("swear", "swore", "sworn"),
        new("sweep", "swept", "swept"),
        new("swell", "swelled", "swollen"),
        new("swim", "swam", "swum"),
        new("swing", "swung", "swung"),
        new("take", "took", "taken"),
        new("teach", "taught", "taught"),
        new("tear", "tore", "torn"),
        new("tell", "told", "told"),
        new("think", "thought", "thought"),
        new("throw", "threw", "thrown"),
        new("understand", "understood", "understood"),
        new("wake", "woke", "woken"),
        new("wear", "wore", "worn"),
        new("weep", "wept", "wept"),
        new("win", "won", "won"),
        new("wind", "wound", "wound"),
        new("write", "wrote", "written"),

    };
    
    public static Verb See = List.FirstOrDefault(x => x.BaseForm == "see");
}