What do you want?

* [Hello] I just wanted to say hi.
* [Don't be rude] You don't have to be so rude.

-
-> Divert1
== Divert1 
Well you're wasting my time. I have a lot of things to get done today.

*[About the cave] Do you know anything about that cave?
    I know that a few years ago...
    **[Go Back] -> Divert1
    
*[About the town] What is going on on town?
    Nothing today. Same as everyday.
    **[Go Back] -> Divert1
    
*[About the lake] Can you tell me about the lake?
    I lost my favorite bracelet in ther... can you get it for me?
    **[Yes] I guess i can find it.
    **[No] No, I don't have time.
    -- -> Divert1
    
*[About the monster] Haven't you noticed the weird tree monsters?
    What monsters? I don't see any monsters.
    **[Right there] They are right here. How can you not see them?
        I don't know what you're talkung about.
        ***[Go Back] -> Divert1
    **[Ooookay] Sure you don't!
        ***[Go Back] -> Divert1

*[Leave] Sorry, I didn't mean to bother you.
    **[Continue] ->EndPart

== EndPart

-> END