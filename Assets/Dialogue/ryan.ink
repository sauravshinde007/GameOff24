INCLUDE globals.ink

{isTalked_ryan == false : -> main | -> already_chose}

=== main ===
You meet Ryan in the nightclub VIP lounge.  
Ryan: "Elysia left this photo with me. Said it might help someone trustworthy."  
+ [Ask Ryan why Elysia trusted him]  
    ~ isTalked_ryan = true  
    ~ total_points += 5  
    -> ryan_trusted  
+ [Ask to see the photo]  
    ~ isTalked_ryan = true  
    ~ total_points += 3  
    -> ryan_photo  
+ [Say you don’t need his help and leave]  
    ~ isTalked_ryan = true  
    ~ total_points += 0  
    -> ignored_ryan  

=== ryan_trusted ===
Ryan: "She said I wasn’t connected to NeuroDyne, but I don’t know why. Here’s the photo."  
Clue Location: Nightclub VIP Lounge Photo  
-> END  

=== ryan_photo ===
Ryan: "Here’s the photo she left. I don’t know if it’ll help you, though."  
Clue Location: Nightclub VIP Lounge Photo  
-> END  

=== ignored_ryan ===
Ryan: "Fine. Good luck."  
-> END  

=== already_chose ===
Ryan: "I already gave you the photo!"  
-> END  
