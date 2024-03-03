// Import styles of packages that you've installed.
// All packages except `@mantine/hooks` require styles imports
import "@mantine/core/styles.css";
import "@mantine/dates/styles.css";
import "@mantine/notifications/styles.css";

import "./index.css";

import React, { PropsWithChildren } from "react";
import ReactDOM from "react-dom/client";
import { BrowserRouter, useNavigate } from "react-router-dom";
import {
  AppState,
  Auth0Provider,
  Auth0ProviderOptions,
} from "@auth0/auth0-react";
import { QueryClient, QueryClientProvider } from "react-query";
import { ReactQueryDevtools } from "react-query/devtools";

import { MantineProvider } from "@mantine/core";
import App from "./App";

import dayjs from "dayjs";
import customParseFormat from "dayjs/plugin/customParseFormat";
import { Notifications } from "@mantine/notifications";

dayjs.extend(customParseFormat);

const Auth0ProviderWithRedirectCallback = ({
  children,
  ...props
}: PropsWithChildren<Auth0ProviderOptions>) => {
  const navigate = useNavigate();

  const onRedirectCallback = (appState?: AppState) => {
    navigate((appState && appState.returnTo) || window.location.pathname);
  };

  return (
    <Auth0Provider onRedirectCallback={onRedirectCallback} {...props}>
      {children}
    </Auth0Provider>
  );
};

const queryClient = new QueryClient();

const root = ReactDOM.createRoot(document.getElementById("root")!);

root.render(
  <React.StrictMode>
    <BrowserRouter>
      <Auth0ProviderWithRedirectCallback
        domain={import.meta.env.VITE_AUTH0_DOMAIN}
        clientId={import.meta.env.VITE_AUTH0_CLIENT_ID}
        authorizationParams={{
          audience: import.meta.env.VITE_AUTH0_AUDIENCE,
          redirect_uri:
            import.meta.env.VITE_AUTH0_REDIRECT_URI + "/login/redirect",
          scope: "openid profile email offline_access",
        }}
        cacheLocation="localstorage"
        useRefreshTokens={true}
      >
        <QueryClientProvider client={queryClient}>
          <MantineProvider defaultColorScheme="auto">
            <Notifications position="bottom-left" zIndex={1000} />
            <App />
          </MantineProvider>
          <ReactQueryDevtools initialIsOpen={false} />
        </QueryClientProvider>
      </Auth0ProviderWithRedirectCallback>
    </BrowserRouter>
  </React.StrictMode>
);
