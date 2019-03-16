%include "asm_io.inc"

segment .data	
	i	 dd	0
	j	 dd	0
	stop	 dd	10
	e	 db     "=",0
	t        db     "*",0
	s        db     " ",0

segment .bss
	temp	resd	4	; result

segment .text
	global asm_main

asm_main:
	enter	0,0
	pusha	
	
	mov eax, 1
	mov [i], eax
for1:
	mov eax, [i]
	mov ebx, [stop]
	cmp eax, ebx
	jz break1
	
	mov eax, 1
	mov [j], eax
for2:
	mov eax, [j]
	mov ebx, [stop]		
	cmp eax, ebx
	jz break2
	
	; i * j  = i*j \n
	
	mov eax, [j]
	call print_int

	mov eax, t
	call print_string

	mov eax, [i]
	call print_int

	mov eax, e
	call print_string

	mov eax, [i]
	mov ebx, [j]
	mul ebx
	call print_int

	mov eax, s
	call print_string

	mov eax, [j] 
	inc eax
	mov [j], eax 

	jmp for2
break2:
	call print_nl

	mov eax, [i] 
	inc eax
	mov [i], eax 
	jmp for1

break1:

	popa
	mov	eax, 0
	leave
	ret
