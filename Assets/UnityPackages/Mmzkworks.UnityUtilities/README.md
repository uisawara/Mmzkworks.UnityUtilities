# Mmzkworks Unity Utilities

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
