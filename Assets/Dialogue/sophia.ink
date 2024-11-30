INCLUDE globals.ink

{isTalked_sophia == false : -> main_sophia | -> already_chose_sophia}

=== main_sophia ===  
Alex meet Sophia, a friendly café worker wiping down tables.  

+ [“I think Elysia’s in trouble. Did she leave anything behind?”]  
    ~ isTalked_sophia = true  
    ~ total_points += 2  
    -> caring_sophia  

+ [“Just tell me if you’ve seen her or not.”]  
    ~ isTalked_sophia = true  
    ~ total_points -= 1  
    -> cold_sophia  

=== caring_sophia ===  
Sophia: "Oh no! That’s terrible. She left this letter in her booth. I didn’t read it, but maybe it’ll help you."  
+1 Clue (Letter) earned!  

Letter Description: *A note from Elysia saying, “I’m being watched. They’re everywhere. I need to lay low.”*  
-> END  

=== cold_sophia ===  
Sophia: "There’s a letter in her booth. That’s all I can tell you."  
+1 Clue (Letter) earned!  
-> END  

=== already_chose_sophia ===  
Sophia: "I already gave you the letter, remember?"  
-> END  
