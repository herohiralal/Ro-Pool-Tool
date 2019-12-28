
# PoolTool

### What?

![IMAGEPLACEHOLDER - inspector fields](/images~/1.png)

A set of MonoBehaviours with custom editors that make up for a robust and modular object pooling system.

### Why?
>"No one wakes up and one day decides they wanna make object pools. They wanna make games, that's why they're there."
> -- Joachim Ante, something along those lines.

Note: I'm quoting him out of context, but that does not deduct the essence of his statement.

Object pools might not be enjoyable to write, but until ECS evolves further, we're stuck with writing them anyway, so let's make the best of it.
You need object pools to cache your instantiated data, so you don't have the processor instantiate it again. Or some technobabble like that.

TL;DR - You need object pools, here's my system for it.

# Main Features:

**1. Modular design.** - Attach only the extensions you need. No more inspector hogging.
**2. Open source.** - The next section explains the already simplistic design and how you can extend it to create your own functionalities.
**3. Designer-friendly UI.** - As a designer myself (and not just a programmer), I feel more comfortable with the Unity editor, rather than within Visual Studio. So I tailored the experience to match that. You can perform almost all tasks of this pooling system from the editor itself.
**4. 10 pre-made extensions.** - And I'll very likely update with more soon. To be more precise I'll write more as I need them. Here's the (currently) exhaustive list:

![IMAGEPLACEHOLDER - extensions](/images~/2.png)

>**Logger**
>Currently only displays the data in the inspector.I plan on extending this functionality to include making graphs and writing actual logs to a json.

>**Initial Populator**
>Makes the pool instantiate a set number of items at Start( ) and then destroys itself after 2 seconds.

>**Static Access For The Pool**
>Provides a method to get the pool using strings.

>**Auto-Return Timer**
>The pooled objects will be called back after a set time (in seconds).

>**Auto Pool Cleanup**
>Destroys inactive pool objects after a certain amount of time (in seconds) of being inactive.

>**Name Override**
>Changes the name of pooled objects for better identification.

>**Unity Event 1 - On Instantiation**
>Unity event upon new object instantiation. Dynamic callback support for the newly instantiated GameObject.

>**Unity Event 2 - On Call**
>Unity event upon a Get() call from the pool. Dynamic callback support for the GameObject that will be delivered to the client.

>**Unity Event 3 - On Return**
>Unity event upon a Return(GameObject) call. Dynamic callback support for the GameObject returning to the pool.

>**Unity Event 4 - On Destroy**
>Unity event before the destruction of the object. Dynamic callback support for the GameObject about to be destroyed.

>**Pool Cap (deprecated)**
>Creates a maximum cap for the pool. After that, will return null game objects.
>Deprecated because you might as well just use the auto-destroy inactive objects extension, with which you can have your optimization, and still render all your particle effects.


# Architecture - Jump to the next section if you do not wish to extend the functionality

This section explains the architecture of this project. Might be helpful in understanding how to add more features to the pool.

Check out IPoolTool interface, that defines 4 basic functions for any pool.

1. Instantiation of the pooled item.
2. Retrieving an item from the pool.
3. Returning the said item to the pool.
4. And destroying any item that the pool stores.

And based on these functions, IPoolTool defines 4 events, that PoolTool MonoBehaviour implements in this way:

1. A callback AFTER instantiation of a GameObject. (on the said 
2. A callback AFTER choosing the GameObject to send for a retrieve call, but BEFORE the GameObject is actually delivered to the caller.
3. A callback AFTER it's returned to the PoolTool MonoBehaviour, but BEFORE it's actually added to the pool queue.
4. A callback BEFORE a GameObject is destroyed permanently.

The abstract class PoolExtension grabs a reference to a PoolTool (using GetComponent\<IPoolTool\>(), so make sure any inherited classes are on the same Object) at Awake() (don't override it completely).

You can access the core functionality of the pool in this manner, and bind functions to any/all of those 4 events.

# How to use?

#### 1. Set-up

>Attach PoolTool MonoBehaviour to any GameObject. Preferably dedicate it to pooling a particular prefab. Use the drop-down and the Add/Remove button to add any extensions. There's also a help-box that explains what that extension does.

![IMAGEPLACEHOLDER - helpbox](/images~/3.png)

#### 2. Grab a reference to the pool.

>There are 3 ways to do this.

>>**1. Basic**
>>Set up an inspector field / use FindGameObject.
```C#
[SerializeField] private PoolTool duic_PoolTool = null;
// Inject the pool from inspector itself.

private IPoolTool iPoolTool => poolTool;
// I generally use interfaces like this, so that my components
// do not form dependencies on other components they do not
// concern themselves with. "duic" stands for "don't use
// in code".
```

>>**2. String ID:**
>>Attach the Static Access extension to the pool, and you can grab a reference using:
```C#
private IPoolTool poolTool = PE02_StaticPoolAccess
	.GetPool("/* insert pool string ID here */");

// You can set up the string ID in the inspector itself.
```
![IMAGEPLACEHOLDER - static pool access inspector field](/images~/4.png)

>>**3. Singleton pattern:**
>>Extend the class PoolToolSingleton and pass the new class as  the generic parameter.
```C#
public class AsteroidPool : GenericPool<AsteroidPool> { }
// And then use this singleton generic in your own class.
```
```C#
private IPoolTool asteroidPool => AsteroidPool.Instance;
```

#### 3. Done!

>Call an object from the pool with:
```C#
poolTool.Get()
	.AtPosition(/*Vector3 position*/)
	.AtRotation(/*Quaternion rotation*/)
	.WithAutoReturnToPoolAfter(poolTool, /*float time*/);
	
// The methods AtPosition(Vector3), AtRotation(Quaternion),
// and WithAutoReturnToPoolAfter(IPoolTool, float) are
// optional. You can use them for extended functionality.

// You can also set-up auto-return as a pool extension,
// and this method will override its value for that particular
// call. After it returns to pool, it'll continue behaving
// according to the global set-up of that pool tool, based
// on the extension.
```

>If you do not use Auto-Return, you'll have to manually return the object to the pool, you can do so with:
```C#
var receivedObject = poolTool.Get();
// ...
// ...
poolTool.Return(receivedObject);
```


# Created by Rohan.
### Thanks.