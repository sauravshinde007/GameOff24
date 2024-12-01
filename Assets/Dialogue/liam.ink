INCLUDE globals.ink

{isTalked_liam == false : -> main | -> already_chose}

=== main ===
You meet Liam in the alley outside the nightclub.  
Liam: "Elysia? Yeah, I know where she lived. But why are you looking for her?"  
+ [Tell Liam you’re worried about Elysia’s safety]  
    ~ isTalked_liam = true  
    ~ total_points += 5  
    -> liam_help  
+ [Say you need answers from Elysia]  
    ~ isTalked_liam = true  
    ~ total_points += 3  
    -> liam_curious  
+ [Refuse to answer Liam and move on]  
    ~ isTalked_liam = true  
    ~ total_points += 0  
    -> ignored_liam  

=== liam_help ===
Liam: "I don’t know if she’s safe, but here’s where she lived. If you’re going, be careful."  
Elysia’s Apartment Unlocked  
-> END  

=== liam_curious ===
Liam: "If you’re just looking for answers, you can try her apartment. But be careful; it’s not safe."  
Elysia’s Apartment Unlocked  
-> END  

=== ignored_liam ===
Liam: "If you don’t trust me, figure it out yourself."  
-> END  

=== already_chose ===
Liam: "I already told you about her apartment. What else do you need?"  
-> END   
