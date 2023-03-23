namespace English.Test;

public class VerbTests
{
    private readonly Verb _sut;
     public VerbTests()
    {

        //ISubject subject = new SubjectPersonalPronouns(Person.First);
        // obj = ObjectPersonalPronouns.Her;
        _sut = new Verb("write", "wrote", "written").ConditionalPerfect();
    }

    [Fact]
    public void TestAllPresentVerbs()
    {
        // Arrange
        var s = SubjectPersonalPronouns.She;

        // Act
        var result = _sut.SimplePresent().ToStringFor(s);
        // Assert
        result.Should().BeEquivalentTo("writes");
        // Act
        result = _sut.PresentContinuous().ToStringFor(s);
        // Assert
        result.Should().BeEquivalentTo("is writing");
        // Act
        result = _sut.PresentPerfect().ToStringFor(s);
        // Assert
        result.Should().BeEquivalentTo("has written");
        // Act
        result = _sut.PresentPerfectContinuous().ToStringFor(s);
        // Assert
        result.Should().BeEquivalentTo("has been writing");
        // Act
        result = _sut.PassiveSimplePresent().ToStringFor(s);
        // Assert
        result.Should().BeEquivalentTo("is being written");
        // Act
        result = _sut.PassivePresentContinuous().ToStringFor(s);
        // Assert
        result.Should().BeEquivalentTo("is being written");
        // Act
        result = _sut.PassivePresentPerfect().ToStringFor(s);
        // Assert
        result.Should().BeEquivalentTo("has been written");
        // Act
        result = _sut.PassivePresentPerfectContinuous().ToStringFor(s);
        // Assert
        result.Should().BeEquivalentTo("has been being written");
    }

    [Fact]
    public void TestAllPastVerbs()
    {
        // Arrange
        var s = SubjectPersonalPronouns.She;

        // Act
        var result = _sut.SimplePast().ToStringFor(s);
        // Assert
        result.Should().BeEquivalentTo("wrote");
        // Act
        result = _sut.PastContinuous().ToStringFor(s);
        // Assert
        result.Should().BeEquivalentTo("was writing");
        // Act
        result = _sut.PastPerfect().ToStringFor(s);
        // Assert
        result.Should().BeEquivalentTo("had written");
        // Act
        result = _sut.PastPerfectContinuous().ToStringFor(s);
        // Assert
        result.Should().BeEquivalentTo("had been writing");
        // Act
        result = _sut.PassiveSimplePast().ToStringFor(s);
        // Assert
        result.Should().BeEquivalentTo("was written");
        // Act
        result = _sut.PassivePastContinuous().ToStringFor(s);
        // Assert
        result.Should().BeEquivalentTo("was being written");
        // Act
        result = _sut.PassivePastPerfect().ToStringFor(s);
        // Assert
        result.Should().BeEquivalentTo("had been written");
        // Act
        result = _sut.PassivePastPerfectContinuous().ToStringFor(s);
        // Assert
        result.Should().BeEquivalentTo("had been being written");
    }

    [Fact]
    public void TestAllFutureVerbs()
    {
        // Arrange
        var s = SubjectPersonalPronouns.She;

        // Act
        var result = _sut.SimpleFuture().ToStringFor(s);
        // Assert
        result.Should().BeEquivalentTo("will write");
        // Act
        result = _sut.FutureContinuous().ToStringFor(s);
        // Assert
        result.Should().BeEquivalentTo("will be writing");
        // Act
        result = _sut.FuturePerfect().ToStringFor(s);
        // Assert
        result.Should().BeEquivalentTo("will has written");
        // Act
        result = _sut.FuturePerfectContinuous().ToStringFor(s);
        // Assert
        result.Should().BeEquivalentTo("will has been writing");
        // Act
        result = _sut.PassiveSimpleFuture().ToStringFor(s);
        // Assert
        result.Should().BeEquivalentTo("will be written");
        // Act
        result = _sut.PassiveFutureContinuous().ToStringFor(s);
        // Assert
        result.Should().BeEquivalentTo("will be being written");
        // Act
        result = _sut.PassiveFuturePerfect().ToStringFor(s);
        // Assert
        result.Should().BeEquivalentTo("will has been written");
        // Act
        result = _sut.PassiveFuturePerfectContinuous().ToStringFor(s);
        // Assert
        result.Should().BeEquivalentTo("will has been being written");
    }

    [Fact]
    public void TestAllConditionalVerbs()
    {
        // Arrange
        var s = SubjectPersonalPronouns.She;

        // Act
        var result = _sut.SimpleConditional().ToStringFor(s);
        // Assert
        result.Should().BeEquivalentTo("would write");
        // Act
        result = _sut.ConditionalContinuous().ToStringFor(s);
        // Assert
        result.Should().BeEquivalentTo("would be writing");
        // Act
        result = _sut.ConditionalPerfect().ToStringFor(s);
        // Assert
        result.Should().BeEquivalentTo("would has written");
        // Act
        result = _sut.ConditionalPerfectContinuous().ToStringFor(s);
        // Assert
        result.Should().BeEquivalentTo("would has been writing");
        // Act
        result = _sut.PassiveSimpleConditional().ToStringFor(s);
        // Assert
        result.Should().BeEquivalentTo("would be written");
        // Act
        result = _sut.PassiveConditionalContinuous().ToStringFor(s);
        // Assert
        result.Should().BeEquivalentTo("would be being written");
        // Act
        result = _sut.PassiveConditionalPerfect().ToStringFor(s);
        // Assert
        result.Should().BeEquivalentTo("would has been written");
        // Act
        result = _sut.PassiveConditionalPerfectContinuous().ToStringFor(s);
        // Assert
        result.Should().BeEquivalentTo("would has been being written");
    }
}