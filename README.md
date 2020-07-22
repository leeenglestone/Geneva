# Geneva
A local voice controlled virtual assistant using C# and .NET

## Requirements (Using Moscow Priority)
* Should work offline (M)
* Activated by name (M)
* Activation name should be configurable (S)
* Have Passive & Active states (M)
* Start in Passive state (M)
* When hearing wake word, change to Active state (M)
* After [a predefined time] in Active State, change to Passive State (M)
* Use Voice Actors (Fivver) for predefined responses - less robotic (C)
* Respond with voice (SpeechSynthesis) where applicable (M)
* Allow voice to be Male or Female (M)


## Use Cases
* Tell the time - "What time is it?" (M)
* Tell the time in Japan - "What time is it in Japan" (C)
* Open Google
* Google [blah]

## To Do
* Implement Configuration class
* Encapsulate Geneva into separate classes (SRP etc)
* Implement Passive and Active States
* Implement Active state timeout
* Implement Tell the time use case
* Implement Male Voice by default
* Investigate different Windows voice 'packs'
