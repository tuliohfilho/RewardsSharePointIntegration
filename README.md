# Guia de Autenticação e Configuração no Azure AD para SharePoint

Este guia detalha como configurar autenticação para acessar o SharePoint via API utilizando o Azure Active Directory.

---

## Formas de Autenticação

### 1. **Autenticação via Usuário (User Delegated Authentication)**
Essa forma de autenticação utiliza as credenciais de um usuário individual. Requer que o usuário esteja autenticado para realizar operações.

### 2. **Autenticação via Aplicativo (App-Only Authentication)**
Nesse caso, um App Registration no Azure AD é usado para autenticar diretamente um aplicativo. É ideal para cenários sem intervenção de usuário.

---

## Pré-requisitos

- **Conta no Azure**: Certifique-se de ter uma assinatura válida no Azure.
- **Permissões administrativas**: Necessário para criar App Registrations no Azure AD.
- **Plano de Acesso ao SharePoint**: Verifique se o locatário tem permissões e licença para uso do SharePoint.

---

## Passo a Passo

### 1. Acesse o portal do Azure
Acesse o portal do Azure em [https://portal.azure.com/#home](https://portal.azure.com/#home).

---

### 2. Abra o Azure Active Directory
Na barra de pesquisa, procure por **Azure Active Directory** ou acesse diretamente pelo link:  
[Azure Active Directory](https://portal.azure.com/#view/Microsoft_AAD_IAM/ActiveDirectoryMenuBlade/~/Overview).

---

### 3. Registre um Aplicativo
1. No menu à esquerda, em **Gerenciar**, clique em **Registros de aplicativos** ou use o link direto:  
   [Registros de Aplicativos](https://portal.azure.com/#view/Microsoft_AAD_IAM/ActiveDirectoryMenuBlade/~/RegisteredApps).
2. Clique em **Novo registro**.
3. Preencha o formulário de registro:
   - **Nome**: Escolha um nome para sua aplicação (ex.: `MinhaAppSharePoint`).
   - **Tipos de conta**: Escolha "Contas nesta organização" para uso interno ou uma opção mais ampla, conforme necessário.
   - **URI de redirecionamento** (opcional): Pode ser configurado depois, se necessário.
4. Clique em **Registrar**.

---

### 4. Obtenha as Credenciais do Aplicativo
1. Após registrar a aplicação, anote os seguintes IDs:
   - **ID do Aplicativo (Client ID)**.
   - **ID do Locatário (Tenant ID)**.
2. Essas informações serão necessárias na sua aplicação.

---

### 5. Configure um Segredo do Cliente (Client Secret)
1. No menu da aplicação registrada, clique em **Certificados e segredos** ou use o link direto:  
   [Certificados e Segredos](https://portal.azure.com/#view/Microsoft_AAD_RegisteredApps/ApplicationMenuBlade/~/Credentials).
2. Em **Segredos do cliente**, clique em **Novo segredo do cliente**.
3. Após criar o segredo, copie o **valor do segredo** imediatamente. Ele será exibido apenas uma vez.
4. Este segredo será utilizado como **Client Secret** na sua aplicação.

---

### 6. Configurar Permissões de API
1. No menu da aplicação registrada, clique em **Permissões de API**.
2. Clique em **Adicionar permissão** e selecione **Microsoft Graph**.
3. Escolha as permissões adequadas ao seu caso:
   - Para leitura: `Sites.Read.All`.
   - Para leitura e gravação: `Sites.ReadWrite.All`.
4. Caso necessário, solicite consentimento do administrador clicando em **Grant admin consent for [Tenant]**.

---

## Observações Importantes

- O **Client Secret** tem validade (geralmente 1 ou 2 anos). Configure lembretes para renová-lo antes de expirar.
- Diferencie entre **Permissões Delegadas** (requerem usuário logado) e **Permissões de Aplicativo** (autenticação independente).

---

## Testes e Validação

Para garantir que sua configuração está correta:

1. Utilize ferramentas como **Postman** ou **cURL** para testar:
   - Gere um token de autenticação com as credenciais configuradas.
   - Teste chamadas à API do Microsoft Graph para verificar o acesso ao SharePoint.
2. Exemplo de endpoint para testar:
   - **Listar sites do SharePoint**: `https://graph.microsoft.com/v1.0/sites`.

---

## Links Úteis

- [Documentação oficial do Azure AD](https://learn.microsoft.com/pt-br/azure/active-directory/)
- [Permissões do Microsoft Graph](https://learn.microsoft.com/pt-br/graph/permissions-reference)
- [API do Microsoft Graph para SharePoint](https://learn.microsoft.com/pt-br/graph/api/resources/sharepoint?view=graph-rest-1.0)

---

## Contato
Para dúvidas ou problemas, entre em contato com o administrador do Azure ou consulte a [documentação oficial do Azure](https://learn.microsoft.com/pt-br/azure/).

