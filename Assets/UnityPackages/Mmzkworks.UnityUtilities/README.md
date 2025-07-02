# Mmzkworks Unity Utilities

## Installation

### UPM

Install via UPM (using Git URL)

```
https://github.com/uisawara/Mmzkworks.UnityUtilities.git?path=Assets/UnityPackages/Mmzkworks.UnityUtilities
```

## Sample code

```c#
public class Sample
{
    public Sample()
    {
        var modelObject = new GameObject("Model")
            .WithChildren(new []{
                new GameObject("AnimatorA")
                    .WithComponent<Animator>()
                    .WithChildren(new[]
                    {
                        GameObjectConstructor.New("root")
                    }),
                new GameObject("AnimatorB")
                    .WithComponent<Animator>()
                    .WithChildren(new[]
                    {
                        GameObjectConstructor.New("root")
                    })
            }).Target;
    }
}
```

## About AI Generation

- This document has been machine translated.
- This repo contains generated code by ChatGPT and Cursor.
