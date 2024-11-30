INCLUDE globals.ink

{isTalked_jack == false : -> main_jack | -> already_chose_jack}

=== main_jack ===  
Alex meet Jack, a nervous mechanic tinkering with a drone.  

+ [“Relax, Jack. Just tell me what you know about Elysia.”]  
    ~ isTalked_jack = true  
    ~ total_points += 2  
    -> reassured_jack  

+ [“Stop wasting my time, Jack. Talk!”]  
    ~ isTalked_jack = true  
    ~ total_points -= 1  
    -> pressured_jack  

=== reassured_jack ===  
Jack: "Alright, alright. She used to hang out at the café nearby. She dropped this photo once. Maybe it’ll help."  
+1 Clue (Photo) earned!  

Photo Description: *A torn photo of Elysia sitting at the café with someone in a hoodie.*  
-> END  

=== pressured_jack ===  
Jack: "Fine. The café. That’s all I know. Here’s a photo she dropped once. Now leave me alone."  
+1 Clue (Photo) earned!  
-> END  

=== already_chose_jack ===  
Jack: "I already told you everything I know!"  
-> END
