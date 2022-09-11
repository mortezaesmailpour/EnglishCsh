using English.Pronouns;

namespace English.Verbs;

public class ModalVerbs
{
    public static List<ModalVerb> All => new() { Can, Could, May, Might, Will, Would, Must, Shall, Should, OughtTo };
    public static ModalVerb Can => new("can");
    public static ModalVerb Could => new("could");
    public static ModalVerb May => new("may");
    public static ModalVerb Might => new("might");
    public static ModalVerb Will => new("will");
    public static ModalVerb Would => new("would");
    public static ModalVerb Must => new("must");
    public static ModalVerb Shall => new("shall");
    public static ModalVerb Should => new("should");
    public static ModalVerb OughtTo => new("Ought to");


}