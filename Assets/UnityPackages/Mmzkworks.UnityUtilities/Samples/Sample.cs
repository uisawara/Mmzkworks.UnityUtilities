using UnityEngine;

namespace Mmzkworks.UnityUtilities
{
    public class Sample : MonoBehaviour
    {
        private void Start()
        {
            // Sample: Avatar building
            var avatarModel = new GameObject("Avatar")
                    .WithChild(new GameObject("root"))
                    .Target;
            var avatar = AvatarBuilder.BuildGenericAvatar(avatarModel, "root");
            
            // Sample: object building
            var modelObject = new GameObject("Model")
                .WithChildren(new []{
                    new GameObject("AnimatorA")
                        .WithComponent<Animator>(c =>
                        {
                            c.avatar = avatar;
                        })
                        .WithComponent<Rigidbody>()
                        .WithComponent<SphereCollider>()
                        .WithChildren(new[]
                        {
                            new GameObject("root")
                        }),
                    new GameObject("AnimatorB")
                        .WithComponent<Animator>()
                        .WithChildren(new[]
                        {
                            new GameObject("root")
                        }),
                    GameObject.CreatePrimitive(PrimitiveType.Sphere)
                        .ToBuildingContext()
                        .Act<Transform>(t => t.localPosition = Vector3.one)
                }).Target;

            // Sample: object query
            var animatorA = modelObject.Q<Animator>("AnimatorA");
            var root = modelObject.Q<Animator>("AnimatorA/root");

            // Sample: Prefab instantiate and setup
            var prefab = new GameObject("SamplePrefab");
            var modelObjectA = GameObject.Instantiate(prefab)
                .ToBuildingContext()
                .Act<Animator>(c =>
                {
                    c.avatar = avatar;
                });
        }

        public class ActorConfig
        {
            public string sourceKey;
        }

        public GameObject Craete(ActorConfig config)
        {
            GameObject prefab = /** find by config.sourceKey from prefab settings **/ null;
            
            // Avatar
            var avatarModel = new GameObject("Avatar")
                .WithChild(new GameObject("root"))
                .Target;
            var avatar = AvatarBuilder.BuildGenericAvatar(avatarModel, "root");
            
            // GameObject
            var modelObject = new GameObject($"Model-{config.sourceKey}")
                .WithChildren(new []{
                    new GameObject("AnimatorA")
                        .WithComponent<Animator>(c =>
                        {
                            c.avatar = avatar;
                        })
                        .WithComponent<Rigidbody>()
                        .WithComponent<SphereCollider>()
                        .WithChildren(new[]
                        {
                            new GameObject("root")
                        }),
                    new GameObject("AnimatorB")
                        .WithComponent<Animator>()
                        .WithChildren(new[]
                        {
                            new GameObject("root")
                        }),
                    GameObject.Instantiate(prefab)
                        .ToBuildingContext()
                        .Act<Transform>(t => t.localPosition = Vector3.one)
                }).Target;

            return modelObject;
        }
    }
}
