   M S B A M L   `   `   `  ���� M  IProject_management, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Project_managementProject_management  .    (Project_management.SML_SectionManagement   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     2local clr-namespace:Project_management       � Title$  SML_SectionManagement��$��562.8��$��1008.2��.��� $��0,0,-333.2,-147.8q� � RowDefinitions �� $��0* ��� .+�&   System.Windows.Controls.DataGrid  -     Name$ sectionsgrid��$
��Left=�$	��222��$��	44,42,0,0q�$	��Top=�$	��440��$��2���� -   $��New section��$
��Left=�$��51��$��573,213,0,0q�$	��Top=�$	��387��$��2���� -   $��Add student��$
��Left=�$��51��$��573,272,0,0q�$	��Top=�$	��387��$��2���� -   $��
Add degree��$
��Left=�$��41��$��573,469,0,0q�$	��Top=�$	��177��$��2��  -   $��
StuSecGrid��$
��Left=�$	��194��$��
44,316,0,0q�$	��Top=�$	��440��$��2���� $��Students in section:��$
��Left=�$��200,285,0,0q�$��2��$	��Top=��� $��Sections��$
��Left=�$��
229,10,0,0q�$��2��$	��Top=��� -   $��NonFullField��$��Non-full sections��$
��Left=�$��702,104,0,0q�$��2��$	��Top=��� $��Section topic:��$
��Left=�$��
588,73,0,0q�$��2��$	��Top=� J� RenderTransformOrigin$ 0.549,-0.746&��� -   $��SecTopField��$
��Left=�$��23��$��
702,76,0,0q�$��2�� �� TextWrapping$
 Wrap=�$��TextBox��$	��Top=�$��90���� -   $
��Find��$
��Left=�$��24��$��665,138,0,0q�$��2��$	��Top=�$��85���� -	   $��Add presence��$
��Left=�$��31��$��573,328,0,0q�$��2��$	��Top=�$	��200���� -
   $��Show presence��$
��Left=�$��778,328,0,0q�$��2��$	��Top=�$	��177��$ 
0.42,0.167&�$��31���� -   $��Remove student��$
��Left=�$��573,364,0,0q�$��2��$	��Top=�$	��200��$��31���� -   $��Degree_field��$
��Left=�$��41��$��755,469,0,0q�$��2��$
 Wrap=�$�� ��$	��Top=�$	��137��