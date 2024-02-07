import { AppShell, Burger, Group, Stack, UnstyledButton } from '@mantine/core';
import { useDisclosure } from '@mantine/hooks';
import classes from './css/Navbar.module.css';
import { ReactNode } from 'react';
import { Link } from 'react-router-dom';
import ColorSchemeToggle from './ColorSchemeToggle';
import { useAuth0 } from '@auth0/auth0-react';

type NavbarProps = {
    isAuthenticated: boolean,
    children: ReactNode
}

export default function Navbar(props: NavbarProps) {
    const [opened, { toggle }] = useDisclosure();
    const { logout } = useAuth0();

    const handleLogout = () => logout({ logoutParams: { returnTo: window.location.origin } })

    if (!props.isAuthenticated) {
        return props.children;
    }

    return (
        <AppShell
            header={{ height: 60 }}
            navbar={{ width: 300, breakpoint: 'sm', collapsed: { desktop: true, mobile: !opened } }}
            padding="md"
        >
            <AppShell.Header>
                <Group h="100%" px="md">
                    <Burger opened={opened} onClick={toggle} hiddenFrom="sm" size="sm" />
                    <Group justify="space-between" style={{ flex: 1 }}>
                        <Group>
                            <UnstyledButton size="xl" fw={600} component={Link} to="/">WhatTheHealth</UnstyledButton>
                            <Group ml="xl" gap="xl" visibleFrom="sm">
                                <UnstyledButton className={classes.control} component={Link} to="/">Home</UnstyledButton>
                            </Group>
                        </Group>
                        <Group>
                            <UnstyledButton className={classes.control} onClick={handleLogout} visibleFrom='sm'>Log out</UnstyledButton>
                            <ColorSchemeToggle />
                        </Group>
                    </Group>
                </Group>
            </AppShell.Header>

            <AppShell.Navbar py="md" px={4}>
                <Stack justify="space-between" style={{ flex: 1 }}>
                    <Stack>
                        <UnstyledButton className={classes.control} component={Link} to="/">Home</UnstyledButton>
                    </Stack>
                    <UnstyledButton className={classes.control} onClick={handleLogout}>Log out</UnstyledButton>
                </Stack>
            </AppShell.Navbar>

            <AppShell.Main>
                {props.children}
            </AppShell.Main>
        </AppShell>
    );
}