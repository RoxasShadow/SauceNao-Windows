[Setup]
AppName               = SauceNao-Windows
AppVerName            = SauceNao-Windows 0.1.6.4
AppPublisher          = Roxas Shadow
AppPublisherURL       = https://github.com/RoxasShadow
AppVersion            = 0.1.6.4
DefaultDirName        = {pf}\SauceNao-Windows
DefaultGroupName      = SauceNao-Windows
UninstallDisplayIcon  = {app}\SauceNao-Windows.exe
Compression           = lzma2
SolidCompression      = yes
OutputDir             = Installer

[Files]
Source: "SauceNao-Windows\bin\Release\SauceNao-Windows.exe"; DestDir: "{app}"
Source: "SauceNao-Windows\bin\Release\Newtonsoft.Json.dll";  DestDir: "{app}"

[code]
var
  ActionPage: TInputQueryWizardPage;
  SauceNaoKey: String;
  ImgurKey: String;
  Proxy: String;
  ExePath: String;
  CmdToExec: String;

procedure InitializeWizard();
begin
  ActionPage := CreateInputQueryPage(wpSelectTasks,
  'Configuration', 'API keys and proxy for the binding to the right click',
  'Check <https://github.com/RoxasShadow/SauceNao-Windows> for instructions on how to obtain the API keys. \
  Leave everything *blank* if you want to skip the binding to the right click.');

  // Add items (False means it's not a password edit)
  ActionPage.Add('SauceNAO API key', False);
  ActionPage.Add('Imgur API key', False);
  ActionPage.Add('Proxy [IP:PORT] (leave blank if none)', False);
end;

function NextButtonClick(CurPageID: Integer): Boolean;
begin
  Result := True;
  if CurPageID = wpReady then begin
    SauceNaoKey := ActionPage.Values[0];
    ImgurKey    := ActionPage.Values[1];
    Proxy       := ActionPage.Values[2];
    ExePath     := ExpandConstant('{app}') + '\SauceNao-Windows.exe';
    CmdToExec   := '"' + ExePath + '"' + ' ' + SauceNaoKey + ' ' + ImgurKey + ' ' + '"%1"' + ' ' + Proxy;

    if (SauceNaoKey <> '') and (ImgurKey <> '') then begin
      RegWriteStringValue(HKEY_CLASSES_ROOT, '*\shell\SauceNao!\command', '', CmdToExec);
    end;
  end
end;