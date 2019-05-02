from openpyxl import load_workbook
from openpyxl.styles import Border, Side, Alignment, Font

wb = load_workbook('OUTPUT.xlsm')
ws = wb[wb.sheetnames[0]]
Alig = Alignment(horizontal="center", vertical="center")

ws['B12'].value = 'N'
ws['C12'].value = 'M'
ws['D12'].value = 'SD'
ws['E12'].value = 't(' + str(ws['C9'].value) + ')'
ws['F12'].value = 'p'
ws['G12'].value = '95%C.I.'
ws['G13'].value = 'LL'
ws['H13'].value = 'UL'
ws['I12'].value = "Cohen's d"
ws['I12'].alignment = Alig
for i in range(ord('B'),ord('H') + 1):
    ws['{}13'.format(chr(i))].alignment = Alig
    ws['{}12'.format(chr(i))].alignment = Alig

ws['A14'].value = ws['A9'].value
ws['B14'].value = round(ws['B3'].value, 2)
ws['C14'].value = round(ws['C3'].value, 2)
ws['D14'].value = round(ws['D3'].value, 2)
ws['E14'].value = round(ws['B9'].value, 2)
ws['F14'].value = round(ws['D9'].value, 2)
ws['G14'].value = round(ws['F9'].value, 2)
ws['H14'].value = round(ws['G9'].value, 2)
ws['I14'].value = round(abs(ws['E9'].value/ws['D3'].value), 2)


for i in range(ord('A'),ord('I') + 1):
    ws['{}14'.format(chr(i))].alignment = Alig

ws.merge_cells('G12:H12')
ws.merge_cells('A12:A13')
ws.merge_cells('B12:B13')
ws.merge_cells('C12:C13')
ws.merge_cells('D12:D13')
ws.merge_cells('E12:E13')
ws.merge_cells('F12:F13')
ws.merge_cells('I12:I13')

border = Side(border_style='thick', color="000000")
font = Font(name='Times New Roman', italic=True)
for i in range(ord('A'),ord('I') + 1):
    ws['{}12'.format(chr(i))].border = Border(top=border)
    ws['{}12'.format(chr(i))].font = font

ws['G13'].border = Border(top=border)
ws['H13'].border = Border(top=border)
ws['G13'].font = font
ws['H13'].font = font

font = Font(name='Times New Roman')
for i in range(ord('A'),ord('I') + 1):
    ws['{}14'.format(chr(i))].border = Border(top=border, bottom=border)
    ws['{}14'.format(chr(i))].font = font



wb.save('STD_OUTPUT.xlsx')
