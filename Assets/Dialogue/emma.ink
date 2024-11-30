INCLUDE globals.ink

{isTalked_emma == false : -> main_emma | -> already_chose_emma}

=== main_emma ===  
You find Emma, Elysia’s protective neighbor, outside the apartment.  

+ [“I’m trying to find Elysia. She’s in danger.”]  
    ~ isTalked_emma = true  
    ~ total_points += 2  
    -> trusted_emma  

+ [“That’s none of your business. Just tell me where she is.”]  
    ~ isTalked_emma = true  
    ~ total_points -= 1  
    -> dismissed_emma  

=== trusted_emma ===  
Emma: "She used to live here. There’s a letter taped under her mailbox. Take it, but be careful."  
+1 Clue (Letter) earned!  

Letter Description: *A final note from Elysia: “If you’ve found this, I’m either gone or waiting in my apartment.”*  
-> END  

=== dismissed_emma ===  
Emma: "There’s a letter under her mailbox. Take it and leave me alone."  
+1 Clue (Letter) earned!  
-> END  

=== already_chose_emma ===  
Emma: "I’ve already told you where to look."  
-> END  
