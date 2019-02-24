; This simple program simply adds to 32-bit integers together
; and stores the results back in memory

%include "asm_io.inc"

segment .data	
	integer1 dd    14			; first int
	integer2 dd    13			; second int

segment .bss

	result1	resd	4	; result
	result2	resd	4	; result
	temp	resd	4	; result

segment .text
	global asm_main
asm_main:
	enter	0,0
	pusha	

	mov 	eax, [integer1]		;
	sub 	eax, [integer2]		;
	shr	eax, 31			;
	mov	[result1], eax		;


	mov 	eax, [integer2]		;
	sub 	eax, [integer1]		;
	shr	eax, 31			;
	mov	[result2], eax		;


	mov	eax, [result2]		;
	sub	eax, [result1]		;
	mov	[temp], eax		;
	

	mov 	eax, 0			;
	sub 	eax, [temp]  		;
	inc	eax			;
	mov 	[temp], eax		;
	add	eax, [temp]		;
	mov 	[temp], eax		;

	mov 	eax, integer1		;
	add 	eax, [temp]		;
	mov	eax, [eax]		;
	call		print_int	;
	call		print_nl	;

	popa
	mov	eax, 0
	leave
	ret
