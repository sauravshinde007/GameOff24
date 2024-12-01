INCLUDE globals.ink

{isTalked_emma == false : -> main | -> already_chose}

=== main ===
You meet Emma outside Elysia’s apartment.  
Emma: "She’s gone, but she left something behind for whoever finds her."  
+ [Ask Emma about Elysia’s disappearance]  
    ~ isTalked_emma = true  
    ~ total_points += 3  
    -> emma_clue  
+ [Ask Emma if she knows where Elysia went]  
    ~ isTalked_emma = true  
    ~ total_points += 5  
    -> emma_hint  
+ [Say you’ll check the apartment yourself]  
    ~ isTalked_emma = true  
    ~ total_points += 0  
    -> ignored_emma  

=== emma_clue ===
Emma: "She said her computer has all the answers. Check under the mailbox for a note."  
Clue Location: Mailbox Letter  
-> END  

=== emma_hint ===
Emma: "She didn’t tell me much, just that her computer holds the truth. Look under the mailbox for her note."  
Clue Location: Mailbox Letter  
-> END  

=== ignored_emma ===
Emma: "Go ahead, but don’t say I didn’t warn you."  
-> END  

=== already_chose ===
Emma: "I gave you the clue already!"  
-> END 
